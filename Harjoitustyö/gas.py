#%%
# Tankkauspeli
# Ohjelman alussa ohjelma kysyy käyttäjältä nimen, sekä ilmoittaa bensanhinnat. 
# ohjelma kysyy käyttäjältä "summa" euromäärän, jolla tankataan.
import datetime
nimi = input("Anna nimesi.")
e98 = "98 1.8€/L""\n"
e95 = "95 1.7€/L""\n"
diesel = "Diesel 1.5€/L""\n"
hinnat = e98 + e95 + diesel

print("Tervetuloa tankkaamaan", nimi.capitalize(), "\n")

kysymys = input("Haluatko nähdä polttoaineiden hinnat?")
if kysymys == "kyllä":
    print(hinnat)
elif kysymys == "en":
    pass   
eurot = int(input("Syötä summa"))

# Ohjelma kysyy käyttäjältä mitä tankataan.
# Syötä ohjelmaan haluttu polttoaine tavalla: 98 , 95 tai diesel. Muussa tapauksessa ohjelma tulostaa: "Virhe! Anna kelvollinen muuttuja (98, 95 tai diesel)."

while True:
    try:
        polttoaine1 = input("Mitä tankataan?")
    except ValueError:
        print("Yritä uudelleen.")
        continue
    if polttoaine1 == "98":
        polttoaine = 1.8
        break
    elif polttoaine1 == "95":
        polttoaine = 1.7
        break
    elif polttoaine1 == "diesel":
        polttoaine = 1.5
        break
    else:
        print(f"Virhe! Anna kelvollinen muuttuja (98, 95 tai diesel).""\n")
        continue

sum4 = eurot / polttoaine
print("Tankkasit polttoainetta:", polttoaine1, round(sum4, 1), "litraa, summalla:", eurot, "euroa.")
print("Kiitos ja tervetuloa uudelleen!")
lopputulos = round(sum4, 1)

# Kuitin tulostus kuitti.txt tiedostoon.

with open("kuitti.txt", "w") as file: 
    file.write("kuitti") 
today = datetime.datetime.today()
f= open("kuitti.txt", "w")
try:
    f.write("---KUITTI---""\n")
    f.write(nimi)
    f.write(" tankkasi: ")
    f.write(f"{today:%H:%M:%S %B %d %Y}""\n")
    f.write(f"{eurot}"" eurolla ")
    f.write(f"{lopputulos}"" Litraa"+".""\n")
    f.write("Kiitos ja tervetuloa uudelleen!")
    f.write("---KUITTI---")
except:
    print("Virhe tiedoston käsittelyssä.")
finally:
    f.close()
#%%