import cv2

cargando =lambda columna, height: print(f"CARGANDO... {round(((columna*100)/height), 2)}")

def image(_path):
    img = cv2.imread(_path)
    return img

def getGRAY(img):
    height, width = len(img), len(img[0])
    for columna in range(height):
        cargando(columna, height)
        for fila in range(width):
            red, green, blue = int(img[columna][fila][2]), int(img[columna][fila][1]), int(img[columna][fila][0])
            numAUX = int(((blue+green+red)+(blue+green+red))/2)
            img[columna][fila][0], img[columna][fila][1], img[columna][fila][2] = int(numAUX), int(numAUX), int(numAUX)
    return img

def save(img, destination, color):
    color.lower()
    newIMG = getGRAY(img)
    cv2.imwrite(f"{destination}/{color}.jpg", newIMG)

# pathImage = "C:/Users/edwin/OneDrive/Documentos/Universidad/Sistemas inteligentes/IA_grayscale_python/perro.png"
# pathSave = "C:/Users/edwin/OneDrive/Documentos/Universidad/Sistemas inteligentes/IA_grayscale_python"
# save(image(pathImage), pathSave, "gray")