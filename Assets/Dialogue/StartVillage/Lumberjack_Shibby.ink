
-> main

=== main ===
Hallo Wanderer!
Wie geht es dir heute?
    +[Gut]
        ->chosen("Es freut mich, dass es dir gut geht.")
    +[Nicht gut]
        ->chosen("Kopf hoch... Es kommen bestimmt bessere Zeiten.")
=== chosen(zustand) ===
{zustand}
Ich wünsche dir einen schönen Aufenthalt.
-> END