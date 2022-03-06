#%%
# Hedelmäpeli
# Ohjelma arpoo 3 symboolia, joista voittavia symbooleja on Kirsikka, Kello, Sitruuna, Appelsiini ja Tähti. 
# Tähti symbooli on pelin arvokkain symbooli ja sillä sen voiton jako jakautuu: 1x tähti = 50p, 2x tähti= 100p ja 3x tähti = päävoitto 1000p.
# Pääkallo symbooli on pisteiden "syöjä" ja myös pelin lopettaja, mikäli ohjelma arpoo 3 pääkalloa.
# Pelin lopettaminen tapahtuu syöttämällä ohjelmaan mitä tahansa muuta kuin kyllä, k, kyllä, K.
# Kierroksella voi voittaa vain yhden voiton, jos ohjelma arpoo 2 samaa symboolia ja tähden pelaajaa voittaa kerran 50 pistettä.
import random
import datetime
nimi = input("Anna nimi.")
credit = 100
print("Moikka", nimi + "!", "\n")
print("Aloita uusi kierros syöttämällä ohjelmaan: 'kyllä', 'k','kyllä'tai'K'", "\n" "Kierros maksaa 20 pistettä", "\n")
def roll(credit):
    sym1 = random.choice(symbols)
    sym2 = random.choice(symbols)
    sym3 = random.choice(symbols)    
    print("\n", "---Uusi kierros---", "-20p","\n")
    print("Symboolit:",sym1, sym2, sym3, "\n")
# Mikäli ohjelma arpoo 2 tähteä, pelaaja voittaa kierroksen ja saa +100 pistettä.
    if (sym1 == sym2 == "Tähti" or sym1 == sym3 == "Tähti" or sym2 == sym3 == "Tähti") and not(sym1 == sym2 == sym3) and not(sym1 == "Pääkallo" or sym2 == "Pääkallo" or sym3 == "Pääkallo"): 
        print("Kaksi Tähteä! Voitit +100 pistettä.")
        credit += 100
        return credit 
# Mikäli ohjelma arpoo 2 samaa symboolia, pelaaja voittaa kierroksen ja saa +50 pistettä. Kierroksella voi voitaa vain yhden voiton.
    elif (sym1 == sym2  or sym1 == sym3 or sym2 == sym3) and not(sym1 == sym2 == sym3) and not(sym1 == "Pääkallo" or sym2 == "Pääkallo" or sym3 == "Pääkallo"):
        print(nimi, "Voitit +50 pistettä!")
        credit += 50
        return credit  
# Mikäli ohjelma arpoo tähden, pelaajaa voittaa + 50 pistettä.
    elif (sym1 == "Tähti" or sym2 == "Tähti" or sym3 == "Tähti") and not(sym1 == sym2 == sym3) and not(sym1 == "Pääkallo" or sym2 == "Pääkallo" or sym3 == "Pääkallo"): 
        print(nimi, "Voitit! +50 pistettä!")
        credit += 50
        return credit
# Mikäli ohjelma arpoo 3 tähteä, pelaaja voittaa päävoiton ja saa +500 pistettä.
    elif (sym1 == sym2 == sym3) and sym1 == "Tähti" and sym2 == "Tähti" and sym3 == "Tähti":
        print(nimi, "Voitit päävoiton! +1000 pistettä!")
        credit += 1000
        return credit     
# Mikäli ohjelma arpoo 3 samaa symboolia, pelaaja voittaa päävoiton ja saa +500 pistettä.
    elif (sym1 == sym2 == sym3):
        print(nimi, "Voitit päävoiton! +500 pistettä!")
        credit += 500
        return credit
# Mikäli ohjelma arpoo 2 pääkalloa, pelaaja menettää -100 pistettä.
    elif (sym1 == sym2 == "Pääkallo" or sym1 == sym3 == "Pääkallo" or sym2 == sym3 == "Pääkallo") and not(sym1 == sym2 == sym3):
        print("Kaksi Pääkalloa! Hävisit -100 pistettä.")
        credit -= 100
        return credit
# Mikäli ohjelma arpoo 3 pääkalloa, pelaaja menettää kaikki pisteensä ja peli loppuu.
    elif (sym1 == sym2 == sym3) and sym1 == "Pääkallo" and sym1 == sym2 and sym2 == sym3:
        print("Kolme Pääkalloa! Hävisit kaikki pisteesi.")
        credit == 0
        return credit
    else:
        print(nimi, "ei voittoa.", "\n")
        return credit
    
# Symboolit

symbols = ["Kirsikka", "Kello", "Sitruuna", "Appelsiini", "Tähti", "Pääkallo"]
print(nimi, "Sinulla on", credit, "pistettä", "\n")

# Kierros ja pelaamisen komennot.

while True:
 play = input("Kierros maksaa 20 pistettä. Pelaatko?")
 if play in {"kyllä","k","kyllä","K"}:
     if credit >= 20:
         credit = roll(credit)
         credit -= 20
         print("Sinulla on", credit, "pistettä" + ".", "\n")
         print("Aloita uusi kierros syöttämällä ohjelmaan: 'kyllä', 'k','kyllä','K'", "\n")
     if credit < 20:
         print("---Peli päättyi---", "\n")
         break
 else:
    print("---Peli päättyi---", "\n")
    break

# Lopeta peli syöttämällä ohjelmaan tyhjärivi.

lopputulos = credit
print(nimi, "Sinulle jäi", lopputulos, "pistettä" + ".")

# Lopuksi ohjelma tulostaa päivämäärän ja lopputuloksen tulos.txt tiedostoon.

with open("tulos.txt", "w") as file: 
  file.write("tulos") 
today = datetime.datetime.today()
f= open("tulos.txt", "w")
try:
    f.write("---TULOS---""\n")
    f.write(nimi)
    f.write(" pelasi: ")
    f.write(f"{today:%H:%M:%S %B %d %Y}""\n")
    f.write("Lopputulos: ")
    f.write(f"{lopputulos}"" p"+".""\n")
    f.write("---TULOS---")
except:
    print("Virhe tiedoston käsittelyssä.")
finally:
    f.close()
#%%