import cv2
import numpy as np
import matplotlib.pyplot as plt
import sys

def lbp_effect(file, save):
    # Cargar imagen en escala de grises y recortarla
    img = cv2.imread(file, cv2.IMREAD_GRAYSCALE)[1:-1, 1:-1]

    # Calcular patrones LBP
    lbp = np.zeros_like(img, dtype=np.int64)
    for i in range(8):
        shifted_img = np.roll(np.roll(img, -1 + i // 3, axis=0), -1 + i % 3, axis=1)
        lbp += (shifted_img >= img) * (1 << i)

    lbp_img = cv2.convertScaleAbs(lbp.astype(np.uint8))
    cv2.imwrite(f'{save}/LBP_Gray.png', lbp_img)

    # Mostrar histograma LBP
    plt.hist(lbp.ravel(), bins=np.arange(257))
    plt.savefig(f'{save}/LBP_Histogram.png')
    plt.show()

lbp_effect(sys.argv[1], sys.argv[2])
