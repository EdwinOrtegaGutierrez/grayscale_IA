import cv2
import plotly.express as px
import pandas as pd
import sys

cargando =lambda columna, height: print(f"CARGANDO... {round(((columna*100)/height), 2)}")

def image(_path):
    img = cv2.imread(_path)
    return img

def getHistogram(img):
    height, width = len(img), len(img[0])
    myMap={}
    print("Leyendo histograma...")

    for columna in range(height):
        for fila in range(width):
            valor = img[columna][fila][0]
            if f"{valor}" in myMap: myMap[f"{valor}"] += 1
            else: myMap.update({f"{valor}":1})
        cargando(columna,height)
    return myMap

def seeHistogram(data):
    # pip install -U kaleido
    num, rep = list(data.keys()), list(data.values())
    data = {"Numeros":num,"Repeticiones":rep}
    df = pd.DataFrame(data)
    fig = px.bar(df, x='Numeros', y='Repeticiones')
    fig.write_image("C:/Users/edwin/OneDrive/Imágenes/histogram.png",width=1355,height=800)

seeHistogram(getHistogram(image(sys.argv[1])))