using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.Widget;

namespace MauiWidgets.Platforms.Android {

    [BroadcastReceiver(Label = "Color press game", Exported = true)]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/color_press_game_widget_provider")]
    [Service(Exported = true)]

    internal class color_press_game_widget_class : AppWidgetProvider {

        /// <summary>
        /// Něco jako konstruktor, povětšinou 2 první řádky zůstávají stejné.
        /// </summary>
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds) {
            ComponentName me = new ComponentName(context, Java.Lang.Class.FromType(typeof(color_press_game_widget_class)).Name);
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context));
        }

        /// <summary>
        /// Metoda BuildRemoteViews vytvoří (aktualizuje) vzhled a fukce widgetu.
        /// </summary>
        private RemoteViews BuildRemoteViews(Context context) {
            RemoteViews widgetView = new RemoteViews(context.PackageName, Resource.Layout.color_press_game_widget_layout);

            // Vytvoření intentů pro různé barvy
            Intent intent_green = new Intent(context, typeof(color_press_game_widget_class));
            Intent intent_blue = new Intent(context, typeof(color_press_game_widget_class));
            Intent intent_red = new Intent(context, typeof(color_press_game_widget_class));
            Intent intent_purple = new Intent(context, typeof(color_press_game_widget_class));
            Intent intent_white = new Intent(context, typeof(color_press_game_widget_class));

            // Nastavení akcí pro jednotlivé barvy
            intent_green.SetAction("chosen_green");
            intent_blue.SetAction("chosen_blue");
            intent_red.SetAction("chosen_red");
            intent_purple.SetAction("chosen_purple");
            intent_white.SetAction("chosen_white");

            // Vytvoření PendingIntent pro jednotlivé barvy
            PendingIntent pendingIntent_green = PendingIntent.GetBroadcast(context, 0, intent_green, PendingIntentFlags.Immutable);
            PendingIntent pendingIntent_blue = PendingIntent.GetBroadcast(context, 0, intent_blue, PendingIntentFlags.Immutable);
            PendingIntent pendingIntent_red = PendingIntent.GetBroadcast(context, 0, intent_red, PendingIntentFlags.Immutable);
            PendingIntent pendingIntent_purple = PendingIntent.GetBroadcast(context, 0, intent_purple, PendingIntentFlags.Immutable);
            PendingIntent pendingIntent_white = PendingIntent.GetBroadcast(context, 0, intent_white, PendingIntentFlags.Immutable);

            // Nastavení onClick PendingIntent pro jednotlivé barvy
            widgetView.SetOnClickPendingIntent(Resource.Id.color_press_game_widget_color_green, pendingIntent_green);
            widgetView.SetOnClickPendingIntent(Resource.Id.color_press_game_widget_color_blue, pendingIntent_blue);
            widgetView.SetOnClickPendingIntent(Resource.Id.color_press_game_widget_color_red, pendingIntent_red);
            widgetView.SetOnClickPendingIntent(Resource.Id.color_press_game_widget_color_purple, pendingIntent_purple);
            widgetView.SetOnClickPendingIntent(Resource.Id.color_press_game_widget_color_white, pendingIntent_white);

            return widgetView;
        }

        /// <summary>
        /// Metoda OnReceive reaguje na kliky na widget.
        /// </summary>
        public override void OnReceive(Context context, Intent intent) {
            RemoteViews widgetView = BuildRemoteViews(context);
            ComponentName me = new ComponentName(context, Java.Lang.Class.FromType(typeof(color_press_game_widget_class)).Name);

            // Nastavení textu pro jednotlivé barvy po kliknutí
            widgetView.SetTextViewText(Resource.Id.color_press_game_widget_color_green, "green");
            widgetView.SetTextViewText(Resource.Id.color_press_game_widget_color_blue, "blue");
            widgetView.SetTextViewText(Resource.Id.color_press_game_widget_color_red, "red");
            widgetView.SetTextViewText(Resource.Id.color_press_game_widget_color_purple, "purple");
            widgetView.SetTextViewText(Resource.Id.color_press_game_widget_color_white, "white");


            switch (intent.Action) {
                case "chosen_green":
                    // Akce pro kliknutí na zelenou
                    widgetView.SetTextViewText(Resource.Id.color_press_game_widget_color_green, "clicked");
                    intent.SetAction("chosen_green");
                    break;
                case "chosen_blue":
                    // Akce pro kliknutí na modrou
                    widgetView.SetTextViewText(Resource.Id.color_press_game_widget_color_blue, "clicked");
                    intent.SetAction("chosen_blue");
                    break;
                case "chosen_red":
                    // Akce pro kliknutí na červenou
                    widgetView.SetTextViewText(Resource.Id.color_press_game_widget_color_red, "clicked");
                    intent.SetAction("chosen_red");
                    break;
                case "chosen_purple":
                    // Akce pro kliknutí na fialovou
                    widgetView.SetTextViewText(Resource.Id.color_press_game_widget_color_purple, "clicked");
                    intent.SetAction("chosen_purple");
                    break;
                case "chosen_white":
                    // Akce pro kliknutí na bílou
                    widgetView.SetTextViewText(Resource.Id.color_press_game_widget_color_white, "clicked");
                    intent.SetAction("chosen_white");
                    break;
                default:
                    // Element nemá nastavenou onClick funkci
                    break;
            }

            AppWidgetManager appWidgetManager = AppWidgetManager.GetInstance(context);

            // Aktualizace widgetu
            appWidgetManager.UpdateAppWidget(me, widgetView);

            // Volání metody z nadřazené třídy
            base.OnReceive(context, intent);
        }
    }
}
