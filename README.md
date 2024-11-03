Dokumentti

Viestisovelluksen backend
Viestisovelluksen käyttäjät tekevät viestisovellukseen oman käyttäjän jolla voivat lähettää viestejä muille henkilöille tai julkaista niitä näkyviin viestisovellukseen kaikille.
Sovelluksessa käyttäjät suojataan UserAuthenticationServicen ja BasicAuthenticationHandlerin avulla ja käyttäjät tunnistetaan oman tunnuksen ja salasanan mukaan, tämä varmistaa sen ettei tuntemattomat pääse kirjautumaan omalle tilille.
Jos käyttäjät haluavat lähettää viestejä sovelluksessa jollekin tietylle henkilölle, on käytettävä käyttäjän Id arvoa, jos viesti lähetetään jollekkin se ei näy muille käyttäjille kuin vastaanottajalle ja lähettäjälle.
Viestien hakeminen jälkeenpäin toimii myös samaa viestin Id:tä käyttäen.
Käyttäjien varmistamiseen liittyvät tiedostot sijaitsevat Middleware kansiossa, jotta jos projektin koodia tarvitsee myöhemmin muuttaa, on tiedostojen paikantaminen huomattavasti helpompaa.
Vierasavaimilla toteutetaan tietojen välisiä yhteyksiä, esimerkiksi, että tietty viesti voidaan yhdistää lähettäjään lähettäjän käyttäjän Id-arvoon viittaamalla.
Käyttäjillä on erilaisia toimintoja käytössään, viestin julkaisu(httpPost), viestin hakeminen(httpGet), viestin poistaminen(httpDelete), uuden käyttäjän luominen(NewUserAsync), käyttäjän poistaminen(DeleteUserAsync)
ja käyttäjän päivittäminen(UpdateUserAsync).
Käyttäjällä on myös muita työkaluja joilla esimerkiksi voi hakea monta viestiä sovelluksesta (GetMyReceivedMessagesAsync).
Käyttäjä voi hyödyntää näitä metodeja ainoastaan omiin luomiin viesteihin ja käyttäjään.
Käyttäjiä voidaan myös hakea sovelluksesta käyttäen GetUserAsync metodia.
Kaikki käyttäjiin liittyvät toiminnot hyödyntää IUserRepository rajapintaa ja IUserService rajapintaa.
Kaikki viesteihin liittyvät toiminnot hyödyntää IMessageRepository rajapintaa ja IMessageService rajapintaa.
Viesteille ja käyttäjille on näiden edellämainittujen rajapintojen vierelle tehty omat tiedostot, joissa käyttäjille ja viesteille kohdistuvia toimintoja käydään läpi, nämä tiedostot sitten kutsuvat rajapintoja ja toteuttavat halutut toiminnot/metodit.
Program.cs tiedostossa sijaitsee kaikki "linkit" joilla yhdistetään valmiita työkaluja tähän harjoitusprojektiin, tämän avulla voidaan käyttää esimerkiksi swaggeria.
Models kansiossa sijaitsevat tiedostot määrittävät viestien ja käyttäjien ominaisuudet ja Services ja Repository kansioiden tiedostot sitten käsittelevät näitä ominaisuuksia kutsuen näitä Models kansion tiedostoja joihin on alustavasti merkitty mitä ominaisuuksia sovelluksella on,(lastlogin, email, password) nämä ovat olioita ja näitä tämän kansion olioita käytetään muissa tiedostoissa.
Controllers kansiossa olevat tiedostot toteuttavat näitä metodeja ja esimerkiksi palauttavat käyttäjälle takaisin viestejä sovelluksesta eri toiminnallisuuksien onnistumisesta. (username not available, badrequest).
