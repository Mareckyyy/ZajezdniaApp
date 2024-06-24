Dokumentacja Techniczna Aplikacji "ZAJEZDNIA"
===================
1	. Wstęp
===================
Aplikacja "ZAJEZDNIA" jest webowym systemem zarządzania wyjazdami tramwajów z zajezdni. Umożliwia logowanie i zarządzanie kontami pracowników oraz administratorów, a także zarządzanie taborem i planowaniem wyjazdów.

2	. Wymagania Systemowe
===================
Platforma: .NET 6.0\
Język programowania: C# z użyciem ASP.NET\
Baza danych: Microsoft SQL Server\
Serwer: Serwer zgodny z ASP.NET

3	. Architektura Systemu
===================
3.1 Architektura aplikacji
===================
Aplikacja składa się z trzech głównych modułów:\
Moduł Zarządzania Użytkownikami: Odpowiada za tworzenie kont, logowanie oraz przydzielanie ról.\
Moduł Zarządzania Wyjazdami: Odpowiada za planowanie i zatwierdzanie wyjazdów tramwajów.\
Moduł Zarządzania Taborem: Odpowiada za dodawanie, usuwanie i edycję danych tramwajów.

3.2 Model danych
===================
Użytkownicy: Tabela przechowująca dane użytkowników wraz z rolami.\
Tramwaje: Tabela przechowująca informacje o pojazdach.\
Wyjazdy: Tabela z planowanymi wyjazdami.

4	. Opis Funkcjonalności
===================
4.1 Panel administratora
===================================
Zarządzanie użytkownikami: Tworzenie, edycja i usuwanie kont użytkowników.\
Zarządzanie taborem: Dodawanie, usuwanie i edycja danych tramwajów, również wczytanie danych z pliku tekstowego.\
Dodawanie ekspedycji: Tworzenie nowych wyjazdów tramwajów.\
Zatwierdzanie ekspedycji: Przeglądanie i zatwierdzanie zaplanowanych wyjazdów.
 
4.2 Panel pracownika
===================================
Dodawanie ekspedycji: Tworzenie nowych wyjazdów tramwajów.

5	. Procedury Instalacji i Konfiguracji
===================
5.1. Wejdź na stronę: https://github.com/Mareckyyy/ZajezdniaApp \
5.2. Pobierz repozytorium w formie pliku .zip.\
5.3. Wypakuj repozytorium.\
5.4. Uruchom plik "Zajezdnia.sln".\
5.5. Uruchom Konsolę Menadżera Pakietów.\
5.6. Wpisz w konsoli "Update-Database".\
5.6.1. W przypadku błędu "The term 'Update-Database' is not recognized as the name of a cmdlet, function, script file, or operable program." wpisz w konsoli "Install-Package Microsoft.EntityFrameworkCore.Tools".\
5.6.2. Po zainstalowaniu narzędzi Entity Framework wpisz ponownie "Update-Database".\
5.7. Skompiluj i uruchom projekt.\
5.8. Aby zarejestrowane konto otrzymało uprawnienia Administratora, w polu Hasło Admina należy wpisać: "Administrator".

6	. Bezpieczeństwo
===================
Autentykacja i autoryzacja: Używanie ASP.NET Identity dla zarządzania bezpieczeństwem dostępu.\
Szyfrowanie hasła: Używanie silnego szyfrowania dla hasła "Administrator".

7	. Changelog
===================
1.0.0 - Pierwsza wersja aplikacji.
