using System.Reflection;

namespace MemoryGame_net7
{
    public partial class Form1 : Form
    {

        List<Icon> _icons = new List<Icon>();
        Random _random= new Random();
        public Form1()
        {
            InitializeComponent();
            LoadImagesFromFiles();
            PopulateIconsToTable();
            ShowCardsInit(true);
        }


        private void ShowCardsInit(bool showCards) 
        {
           pnlcover1.Visible = !showCards;
           pnlcover2.Visible = !showCards;
           pnlcover3.Visible = !showCards;
           pnlcover4.Visible = !showCards;
           pnlcover5.Visible = !showCards;
           pnlcover6.Visible = !showCards;
           pnlcover7.Visible = !showCards;
           pnlcover8.Visible = !showCards;
           pnlcover9.Visible = !showCards;
           pnlcover10.Visible = !showCards;
           pnlcover11.Visible = !showCards;
           pnlcover12.Visible = !showCards;
           pnlcover13.Visible = !showCards;
           pnlcover14.Visible = !showCards;
           pnlcover15.Visible = !showCards;
           pnlcover16.Visible = !showCards;

            TimeInit.Start();


        }

        private void TimeInit_Tick(object sender, EventArgs e)
        {
            TimeInit.Stop();
            ShowCardsInit(false);
            TimeInit.Dispose();
        }

        private void LoadImagesFromFiles() 
        
        {
                var files = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            int id = 1;

            foreach (var picture in files)
            {
                if (!picture.EndsWith(".png"))
                    continue;

                var icon = new Icon()
                {
                    Id = id,
                    Name = picture.Replace("MemoryGame_net7.Resources.", "").Replace(".png", ""),
                    Image = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(picture))


                };
                _icons.Add(icon);
                _icons.Add(icon);

                id++;

            }
        }

        //método para recorrer todos los controles de tipo panel
        private void PopulateIconsToTable()
        {
            Panel panel;
            int randomNumber;
            foreach (var item in this.Controls)
            {
                if (item is Panel && !((Panel)item).Name.Contains("pnlcover"))
                    panel = (Panel)item;
                else
                    continue;


                randomNumber = _random.Next(0, _icons.Count);
                if (_icons.Count == 0)
                    break;
                panel.BackgroundImage = _icons[randomNumber].Image;

                _icons.RemoveAt(randomNumber);
            }
        }


    }
}