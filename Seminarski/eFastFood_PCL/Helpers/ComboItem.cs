namespace eFastFood_PCL.Helpers
{
    public class ComboItem
    {
        public int ID { get; set; }
        public string Text { get; set; }

        public ComboItem()
        {
        }
        public ComboItem(int id, string text)
        {
            ID = id;
            Text = text;
        }
    }
}
