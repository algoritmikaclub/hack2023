#Распознавание лиц в реальном времени c размытием фона
#Алгоритм распознавания:
#1.	Загрузка камеры
#2.	Загружаем модель
#3.	Получаем кадры при помощи цикла
#4.	Делаем картинку чёрно-белой
#5.	Применяем фильтр размытия
#6.	Используя модель, мы загружаем изображение
#7.	Распознаём 
#8.	Вырезаем распознанное изображение так чтоб фон был размыт, а наш распознанный объект остался не размытым
#9.	Выводим 




# Для Подключения Библиотеки Open CV
# pip install opencv-python


import cv2

# Подключаем камеру
video_capture = cv2.VideoCapture(0)


# Загрузка предварительно обученного классификатора для лиц
face_cascade = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml')
# Цикл для получение кадров
while True:
    # Считывания кадров с камеры
    ret, frame = video_capture.read()

    # Преобразование фото в оттенки серого
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)

    # Применяем фильтр размытия
    blur_face = cv2.GaussianBlur(frame, (55,55), 100)

    # Обнаружение лиц на фото
    faces = face_cascade.detectMultiScale(gray, scaleFactor=1.1, minNeighbors=20, minSize=(30, 30))

    # Создание обводки и текста
    for (x, y, w, h) in faces:
        #Вырезаем распознанное изображение так чтоб фон был размыт, а наш распознанный объект остался не размытым
        blur_face[y:y+h, x:x+w] = frame[y:y+h, x:x+w]
       
        cv2.rectangle(blur_face, (x, y), (x+w, y+h), (0, 255, 0), 2)
        cv2.putText(blur_face, 'Face', (x+5,y-5), cv2.FONT_HERSHEY_SIMPLEX, 3, (0,255,0), 7)

    cv2.imshow('Video', blur_face)

# Выход из программы по нажатию  кнопки "q"
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break


video_capture.release()
cv2.destroyAllWindows()