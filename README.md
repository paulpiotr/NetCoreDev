## Zadanie Junior .Net Core Developer Test

# Instalacja

 - 1) Pobieranie repozytorium - należy sklonować repozytorium
 - Komenda: git clone https://piotrpaul@dev.azure.com/piotrpaul/NetCoreDev/_git/NetCoreDev
 - 2) Należy zaciągnąć sub-moduły
 - Komenda: git submodule init && git submodule update && git submodule foreach git pull origin master
 - 3) Baza danych: Założyłem bazę danych MSSQL używając pliku MDF. Plik z strukturą znajduje się w lokalizacji NetCoreDev\AdvertisingCampaign\Data. Plik dołączyłem do repozytorium i załączam przy kompilacji do katalogu z projektem. Można skopiować pliki AdvertisingCampaignDatabase.mdf i AdvertisingCampaignDatabase_log.ldf do innej lokalizacji i zmienić ConnectionStrings w NetCoreDev\WebApplicationNetCoreDev\appsettings.json - ustawiamy wartość dla parametru AdvertisingCampaignContext lub stworzyć bazę danych w MsSQL - skrypty tabel NetCoreDev\AdvertisingCampaign\Data\dbo.AdvertisingCampaign.sql NetCoreDev\AdvertisingCampaign\Data\dbo.AdvertisingCampaignAudit.sql
 - 4) Po uruchomieniu projektu (ustawiamy WebApplicationNetCoreDev jako startowy) trzeba się zalogować używając danych do logowania z systemu Windows - logowanie takie jak do konta windows.
 # Używanie
 - 5) w celu operacji na kampaniach reklamowych wybieramy z menu po lewej stronie Advertising / Advertising Campaign List - lista lub Advertising / Advertising Campaign Add - dodawanie. Uwaga dane zapisują się w bazie która dołącza się do kompilacji. Każdorazowa kompilacja aplikacji powoduje skopiowanie bazy do katalogu z binarkami projektu i nie będzie już tam danych. Aby tego uniknąć trzeba skopiować bazę do innej lokalizacji i zmienić ConnectionStrings - opis powyżej.
 - 6) Co do punktu moc nacisnąć guzik Raport - dane zliczają się automatycznie w wyzwalaczach, więc każdorazowe odświeżenie lub wczytanie listy ma już aktualny stan.
 - 7) W razie potrzeby pozostaję w kontakcie - mam nadzieję że projekt nie sprawia problemów przy testowaniu.