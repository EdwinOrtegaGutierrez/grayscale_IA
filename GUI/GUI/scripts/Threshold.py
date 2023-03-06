import cv2
import sys

def threshold(file, save):
    # leer la imagen en escala de grises
    img = cv2.imread(file, cv2.IMREAD_GRAYSCALE)

    # aplicar el umbral
    umbral, img_umbralizada = cv2.threshold(img, 50, 200, cv2.THRESH_BINARY)

    # mostrar la imagen umbralizada
    cv2.imwrite(f"{save}/umbral.png", img_umbralizada)

threshold(sys.argv[1], sys.argv[2])
