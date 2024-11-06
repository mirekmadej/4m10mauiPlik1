namespace _4m10mauiPlik1
{
    class Plyta
    {
        public string wykonawca { get; set; }
        public string tytul { get; set; }
        public int liczbaUtworow { get; set; }
        public int rokWydania { get; set; }
        public long liczbaPobran { get; set; }
        public override string ToString()
        {
            string s = wykonawca + "; "+tytul;
            s += liczbaUtworow.ToString() + "; ";
            s += rokWydania.ToString() + "; ";
            s += liczbaPobran.ToString() + "; ";
            return s;
        }
    }
    public partial class MainPage : ContentPage
    {
        private static List<Plyta> plyty = new List<Plyta>();

        public MainPage()
        {
            InitializeComponent();
            string dane = "";
            

            wczytajDane();

            dane = "";
            foreach (var p in plyty)
                dane += p + "\n";
            lblDane.Text = dane;
        }

        private static void wczytajDane()
        {
            string wiersz;
            using (FileStream f = File.OpenRead(@"C:\Users\mm\source\repos\4m10mauiPlik1\4m10mauiPlik1\Data.txt"))
            using (TextReader sr = new StreamReader(f))
            {
                while ((wiersz = sr.ReadLine()) != null)
                {
                    if (wiersz.Length == 0) break;
                    Plyta plyta = new Plyta();
                    plyta.wykonawca = wiersz;
                    plyta.tytul = sr.ReadLine();
                    plyta.liczbaUtworow = int.Parse(sr.ReadLine());
                    plyta.rokWydania = int.Parse(sr.ReadLine());
                    plyta.liczbaPobran = long.Parse(sr.ReadLine());
                    plyty.Add(plyta);
                }
            }

            
        }

    }

}
