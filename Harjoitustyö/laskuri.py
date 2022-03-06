#%%
# Katso readme.dm. 
# Ohjelma toimii bensankulutus laskurina. 
# Ohjelma kysyy käyttäjältä matkan, bensanhinna, sekä ajoneuvon keskikulutuksen 100 km kohde. 

matka = int(input("Syötä matka"))
bensanhinta = float(input("Syötä bensanhinta"))
keskikulutus = float(input("Syötä kulutus 100 km kohden"))

kulutus = matka / 100* keskikulutus
hinta100 = bensanhinta * keskikulutus
euroa = kulutus * bensanhinta
litrat = kulutus * matka /100

#kul = float("%.1f" % (matka / 100* kulutus))

print("100 km maksaa",round(hinta100, 1), "euroa.")
print(matka,"km matka", keskikulutus, "L/100km kulutuksella", "maksaa", round(euroa,1), "euroa.")
print("kokonaiskulutus",round(kulutus, 2),"Litraa")
#%%
print("Pääset", round(kulutus, 1),"km", "litralla polttoainetta.")