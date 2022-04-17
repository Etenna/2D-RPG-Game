-> main

=== main ===
Möchten sie hier übernachten?
    + [Ja]
        -> chosen("Ich wünsche Dir eine angenehme Nachtruhe!")
    + [Nein]
        -> chosen("Dann halt nicht! Wenn du es dir anders überlegst. Komme ruhig hier zurück.")
    + [Vielleicht]
        -> chosen("Überlege es dir gut! Hier gibt es warme Getränke und Speisen.")
        
=== chosen(uebernachten) ===
{uebernachten}!
-> END