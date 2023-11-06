namespace TimeAndDateWidgetMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            TimeSetter();
        }

        private System.Timers.Timer timer;

        public void TimeSetter()
        {
            timer = new System.Timers.Timer(1000); // 1000 milliseconds = 1 second
            timer.Elapsed += (sender, e) => TimeUpdater();
            timer.AutoReset = true;
            timer.Start();
        }

        private void TimeUpdater()
        {
            Dispatcher.Dispatch(() =>
            {
                timeLabel.Text = DateTime.Now.ToString("H:mm:ss\nd.M.yyy");
            });
        }

    }
}