from PyQt5.QtWidgets import (
    QWidget, QPushButton, QVBoxLayout,
    QFileDialog, QApplication
)
from PyQt5.QtCore import Qt
from PyQt5.QtGui import QIcon
from windows import win_test

class MainWindow(QWidget):
    def __init__(self):
        super().__init__()
        self.set_win()
        self.initUI()
        self.connects()
        self.show()
    
    def set_win(self):
        ''' Настройки экрана '''
        self.setWindowTitle('Моя первая программа')
        self.resize(400, 400)
        # self.setWindowFlags(Qt.FramelessWindowHint)
        self.setStyleSheet('''
        background: rgba(64, 64, 64, 150);
        ''')
    
    def initUI(self):
        ''' Создание виджетов и направляющих '''
        layout = QVBoxLayout()

        self.b_malware = QPushButton('Сканировать файл')
        self.b_malware.setStyleSheet('''
        background: rgba(0, 0, 153, 255);
        font-size: 32px;
        color: rgba(255, 255, 255, 255);
        border: 5px solid rgba(160, 160, 160, 255);
        border-radius: 15px;
        padding: 15px;
        min-width: 300px;
        ''')
        self.b_exit = QPushButton('Выход')
        self.b_exit.setStyleSheet('''
        background: rgba(0, 0, 153, 255);
        font-size: 32px;
        color: rgba(255, 255, 255, 255);
        border: 5px solid rgba(160, 160, 160, 255);
        border-radius: 15px;
        padding: 15px;
        min-width: 300px;
        ''')

        layout.addWidget(self.b_malware, alignment=Qt.AlignCenter)
        layout.addWidget(self.b_exit, alignment=Qt.AlignCenter)

        self.setLayout(layout)

    def connects(self):
        ''' Подключение событий '''
        self.b_malware.clicked.connect(self.click_malware)
        self.b_exit.clicked.connect(QApplication.quit)
    
    def click_malware(self):
        self.cur_file = QFileDialog.getOpenFileName()[0]
        if not self.cur_file == '':
            self.tw = win_test.TestWin(self.cur_file)

    def mousePressEvent(self, event):
        if event.button() == Qt.LeftButton:
            self.draggable = True
            self.dragging_position = event.globalPos() - self.frameGeometry().topLeft()
            event.accept()
    
    def mouseMoveEvent(self, event):
        if self.draggable and event.buttons() & Qt.LeftButton:
            self.move(event.globalPos() - self.dragging_position)
            event.accept()

    def mouseReleaseEvent(self, event):
        if event.button() == Qt.LeftButton:
            self.draggable = False
            event.accept()
        
        