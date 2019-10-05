using eFastFood_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecomandationSystem
{
    public class RecommenderSystem
    {
        private readonly eFastFoodEntitie _db;

        int numberOfSimmilarUsers = 2;
        Dictionary<int, List<Ocjena>> matricaRatings = new Dictionary<int, List<Ocjena>>();
        Dictionary<int, double> preporuceniProizvodi = new Dictionary<int, double>();
        Dictionary<int, double> simmilarity = new Dictionary<int, double>();


        List<int> users = new List<int>();
        List<Ocjena> ratingsOfThisUser = new List<Ocjena>();
        List<Ocjena> ratingsOfOthers = new List<Ocjena>();
        double denominatorUser = 0;

        public RecommenderSystem() => _db = new eFastFoodEntitie();

        public Dictionary<int, double> GetRecomended(int userId)
        {
            GetUsersData(userId);


            Parallel.ForEach(users, item =>
            {
                var sim = GetSimilarity(item);

                simmilarity.Add(item, sim);
            });

            simmilarity = SortDictionaryByValue(simmilarity);

            var topusers = simmilarity.Take(numberOfSimmilarUsers).ToList();

            double sumOfsim = topusers.Sum(x => x.Value);

            foreach (var gotoviProizvod in _db.GotoviProizvod)
            {
                double totalSum = 0;
                foreach (var c in topusers)
                {
                    var rating = matricaRatings[c.Key].Where(m => m.GotoviProizvodID == gotoviProizvod.GotoviProizvodID).FirstOrDefault();

                    if (rating != null)
                        totalSum += c.Value * rating.NumerickaOcjena;
                }

                double simVal = totalSum / sumOfsim;
                preporuceniProizvodi.Add(gotoviProizvod.GotoviProizvodID, simVal);
            }

            return SortDictionaryByValue(preporuceniProizvodi).Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private double GetSimilarity(int otherUserId)
        {
            double denominatorOthers = 0, numerator = 0;

            denominatorOthers = Math.Sqrt(ratingsOfOthers.Where(x => x.KlijentID == otherUserId).Sum(x => Math.Pow(x.NumerickaOcjena, 2)));
            var filteredRating = ratingsOfOthers.Where(x => x.KlijentID == otherUserId).ToList();

            Parallel.ForEach(ratingsOfThisUser, rating =>
            {
                numerator += filteredRating.Where(x => x.GotoviProizvodID == rating.GotoviProizvodID).Select(x => x.NumerickaOcjena * rating.NumerickaOcjena).ToList().Sum();
            });

            var denominator = denominatorUser * denominatorOthers;
            return denominator == 0 ? 0 : Math.Sqrt(numerator / denominator);
        }

        private void GetUsersData(int userId)
        {
            users = _db.Ocjena.Select(x => x.KlijentID).Distinct().ToList();

            ratingsOfThisUser = _db.Ocjena.Where(x => x.KlijentID == userId).ToList();
            ratingsOfOthers = _db.Ocjena.Where(x => x.KlijentID != userId).ToList();

            Parallel.ForEach(users, u => matricaRatings.Add(u, ratingsOfOthers.Where(x => x.KlijentID == u).ToList()));

            denominatorUser = Math.Sqrt(ratingsOfThisUser.Sum(x => Math.Pow(x.NumerickaOcjena, 2)));
        }
        public static Dictionary<int, double> SortDictionaryByValue(Dictionary<int, double> data)
        {
            var myList = data.ToList();

            myList.Sort((pair1, pair2) => -1 * pair1.Value.CompareTo(pair2.Value));

            return myList.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
