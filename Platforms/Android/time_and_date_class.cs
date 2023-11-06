using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.Widget;
using Color = Android.Graphics.Color;

namespace TimeAndDateWidgetMaui.Platforms.Android
{
    [BroadcastReceiver(Label = "Time and date", Exported = true)]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/time_and_date_widget_provider")]
    [Service(Exported = true)]
    internal class time_and_date_class : AppWidgetProvider
    {
        private System.Timers.Timer timer;

        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(time_and_date_class)).Name);
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context));


            // Create and start a timer to update the widget every 1 second
            timer = new System.Timers.Timer(1000); // 1000 milliseconds = 1 second
            timer.Elapsed += (sender, e) => UpdateWidgetText(appWidgetManager, appWidgetIds, context);
            timer.AutoReset = true;
            timer.Start();
        }

        private RemoteViews BuildRemoteViews(Context context)
        {
            // Build widget layout
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.time_and_date_widget_layout);

            // Initial update of text
            SetTextViewText(widgetView);

            // ------------------------------------------------------------------------------------------------

            // když se klikne na widget, tak něco
            // !!POZOR PŘI POUŽÍVÁNÍ S VLÁKNOVÁNÍM (nefunguje s 1 sekundou, ale 1 minutou (60 sekund) funguje)!!!

            // Create an intent to handle the button click 
            Intent intent = new Intent(context, typeof(time_and_date_class));
            intent.SetAction("YOUR_ACTION_STRING"); // Replace with a unique action string

            // Create a PendingIntent for the button's click event
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, 0, intent, PendingIntentFlags.Immutable);

            // Set the PendingIntent as the click action for the button
            widgetView.SetOnClickPendingIntent(Resource.Id.textView1, pendingIntent);
            // ------------------------------------------------------------------------------------------------

            return widgetView;
        }

        private void UpdateWidgetText(AppWidgetManager appWidgetManager, int[] appWidgetIds, Context context)
        {
            var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(time_and_date_class)).Name);
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.time_and_date_widget_layout);
            SetTextViewText(widgetView);
            appWidgetManager.UpdateAppWidget(me, widgetView);
        }

        private void SetTextViewText(RemoteViews widgetView)
        {

            widgetView.SetTextViewText(Resource.Id.textView1, DateTime.Now.ToString("H:mm:ss\nd.M.yyy"));
        }

        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == "YOUR_ACTION_STRING") // Replace with the same action string used above
            {
                // nejedná se o kódy z této apliakce, musí být praveny
                

                /*

                // UPRAVUJE ATRIBUTY ELEMENTU


                // Update the widget UI by modifying the RemoteViews
                Random r = new Random();
                var widgetView = new RemoteViews(context.PackageName, Resource.Layout.time_and_date_widget_layout);
                widgetView.SetTextColor(Resource.Id.textView1, Color.Rgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256)));

                // Update the widget using AppWidgetManager
                AppWidgetManager appWidgetManager = AppWidgetManager.GetInstance(context);
                ComponentName componentName = new ComponentName(context, Java.Lang.Class.FromType(typeof(time_and_date_class)).Name);
                appWidgetManager.UpdateAppWidget(componentName, widgetView);
                
                */

                // -----------------------------------------------------------------------------------------------------------------------

                /*

                     // SPOUŠTÍ HLAVNÍ APLIKACI

                 Intent openAppIntent = new Intent(context, typeof(MainActivity));


                 // Specify the action to navigate to the MainPage
                 openAppIntent.SetAction("android.intent.action.MAIN");
                 openAppIntent.AddCategory("android.intent.category.LAUNCHER");

                 // Start the activity with the intent
                 openAppIntent.SetFlags(ActivityFlags.NewTask);
                 context.StartActivity(openAppIntent);
                */
                 
                // -----------------------------------------------------------------------------------------------------------------------

                /*
                 
                    // NON-Static - updatuje UpdateButtonTextMessage text na click -> následně MainPage.xaml.cs nastaví daný text na text buttonů v MainPage


                var message = new UpdateButtonTextMessage();
                message.setString(click.ToString());
                MessagingCenter.Send(message, "UpdateButtonTextMessage");

                */

                // -----------------------------------------------------------------------------------------------------------------------

                /*
                 
                    // Static - updatuje UpdateButtonTextMessage text na click -> následně MainPage.xaml.cs nastaví daný text na text buttonů v MainPage

                UpdateButtonTextMessage.setString(click.ToString());

                */

            }

            base.OnReceive(context, intent);
        }
    }
}
