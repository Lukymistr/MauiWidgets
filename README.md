# TimeAndDateWidgetMaui
 Maui app that shows time and date + have widget
### soubory
- [TimeAndDateWidgetMaui.csproj](TimeAndDateWidgetMaui.csproj)
   - <ApplicationTitle> -> změna názvu
- [Platforms](Platforms/)
   - [Android](Platforms/Android/)
      - [Resources](Platforms/Android/Resources/)
         - [drawable](Platforms/Android/Resources/drawable/)
            - [time_and_date.png](Platforms/Android/Resources/drawable/time_and_date.png)
               - náhled widgetu při přidávání na plochu
         - [layout](Platforms/Android/Resources/layout)
            - [time_and_date_widget_layout.xml](Platforms/Android/Resources/layout/time_and_date_widget_layout.xml)
               - struktura widgetu
         - [values](Platforms/Android/Resources/values)
            - [colors.xml](Platforms/Android/Resources/values/colors.xml)
               - kódy užitcýh barev (informativní)
         - [xml](Platforms/Android/Resources/xml)
            - [time_and_date_widget_provider.xml](Platforms/Android/Resources/xml/time_and_date_widget_provider.xml)
               - struktura celého widgetu (př. minimální velikost)
      - [time_and_date_class.cs](Platforms/Android/time_and_date_class.cs)
         - je zde celé gró widgetu
- [Resources](Resources/)
   - icony, fonty, obrázky, styly a aplikace
- [App.xaml](App.xaml)
   - načítaní barev a stylů z "Resources"
- [App.xaml.cs](App.xaml.cs)
   - výchozí bod při spuštění aplikace
   - spustí "App.xaml"
   - vyvoří instanci "AppShell.xaml.cs"
- [AppShell.xaml](AppShell.xaml)
   - nastavení aplikace -> načte grafiku z "MainPage.xaml" + přidá (př. nadpis)
- [AppShell.xaml.cs](AppShell.xaml.cs)
   - spustí "AppShell.xaml"
- [MainPage.xaml](MainPage.xaml)
   - výchozí grafický kontent aplikace
- [MainPage.xaml.cs](MainPage.xaml.cs)
   - funkcionalita pro "MainPage.xaml"

### Aplikace
- Čas je řešen přes vlákna, každou sekudnu se přepíše stávající čas na nový, který se vezme a zformátuje z [DateTime][DATE]
- Barva textu je "#ffffff" (bílá)
- Barva pozadí je "#303030" (šedá)

### Android widget
- #### grafika
  - Barva textu je "#ffffff" (bílá)
  - Barva pozadí průhledná

- #### funkcionalita
  - Čas je řešen přes vlákna, každou sekudnu se přepíše stávající čas na nový, který se vezme a zformátuje z [DateTime][DATE]
    - tato funkcionatlita se schována v souboru [time_and_date_class.cs](Platforms/Android/time_and_date_class.cs) v metodě [UpdateWidgetText](Platforms/Android/time_and_date_class.cs#L57)


   [DATE]: <https://learn.microsoft.com/cs-cz/dotnet/api/system.datetime?view=net-7.0>
