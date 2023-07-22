#Распознавание лиц на загруженных изображениях
#Алгоритм распознавания:
#1.	Загружаем изображение
#2.	Загружаем модель
#3.	Делаем картинку чёрно-белой
#4.	Используя модель мы загружаем изображение
#5.	Распознаём 


# Для Подключения Библиотеки Open CV
# pip install opencv-python


import cv2


image = cv2.imread('вставляем название нашей картинки')
# Преобразование фото в оттенки серого

# Загрузка предварительно обученного классификатора для лиц
face_cascade = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml')

# Загрузка фото
gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

# Обнаружение лиц на фото
faces = face_cascade.detectMultiScale(gray, scaleFactor=1.1, minNeighbors=10, minSize=(30, 30))

# Рисование прямоугольников вокруг обнаруженных лиц
for (x, y, w, h) in faces:
    cv2.rectangle(image, (x, y), (x+w, y+h), (0, 255, 0), 2)

# Отображение результата
cv2.imshow("", image)
cv2.imwrite('face.jpg', image)
cv2.waitKey(0)
cv2.destroyAllWindows()