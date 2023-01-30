import cv2

cargando =lambda columna, height: print(f"CARGANDO... {round(((columna*100)/height), 2)}")

def image(_path):
    img = cv2.imread(_path)
    return img

def getBLUE(img):
    height, width = len(img), len(img[0])
    for columna in range(height):
        cargando(columna, height)
        for fila in range(width):
            img[columna][fila][1], img[columna][fila][2] = 0, 0
    return img

def getRED(img):
    height, width = len(img), len(img[0])
    for columna in range(height):
        cargando(columna, height)
        for fila in range(width):
            img[columna][fila][0], img[columna][fila][1] = 0, 0
    return img

def getGREEN(img):
    height, width = len(img), len(img[0])
    for columna in range(height):
        cargando(columna, height)
        for fila in range(width):
            img[columna][fila][0], img[columna][fila][2] = 0, 0
    return img

def getGRAY(img):
    height, width = len(img), len(img[0])
    for columna in range(height):
        cargando(columna, height)
        for fila in range(width):
            red, green, blue = int(img[columna][fila][2]), int(img[columna][fila][1]), int(img[columna][fila][0])
            numAUX = int((blue+green+red)/3)
            img[columna][fila][0], img[columna][fila][1], img[columna][fila][2] = int(numAUX), int(numAUX), int(numAUX)
    return img

def switch(select, img):
    if (select == "red"):
        newIMG = getRED(img)
        return newIMG
    elif(select == "blue"):
        newIMG = getBLUE(img)
        return newIMG
    elif(select == "green"):
        newIMG = getGREEN(img)
        return newIMG
    elif(select == "gray"):
        newIMG = getGRAY(img)
        return newIMG
    else: print("Los colores admitidos son: red, green, blue, gray")

def save(img, destination, color):
    color.lower()
    newIMG = switch(color, img)
    cv2.imwrite(f"{destination}/{color}.png", newIMG)

# pathImage = "C:/Users/edwin/OneDrive/Documentos/Universidad/Sistemas inteligentes/IA_grayscale_python/perro.png"
# pathSave = "C:/Users/edwin/OneDrive/Documentos/Universidad/Sistemas inteligentes/IA_grayscale_python"
# save(image(pathImage), pathSave, "gray")
