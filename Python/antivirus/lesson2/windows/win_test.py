from PyQt5.QtWidgets import (
    QWidget, QVBoxLayout, QScrollArea, QLabel
)
from PyQt5.QtCore import Qt
from helpers import virustotal

class TestWin(QWidget):
    def __init__(self, cur_file):
        super().__init__()
        self.cur_file = cur_file
        self.set_win()
        self.initUI()
        self.show()
    
    def set_win(self):
        ''' Настройки экрана '''
        self.setWindowTitle('Тестовый экран')
        self.resize(400, 400)
        self.setStyleSheet('''
        background: rgba(64, 64, 64, 150);
        ''')
    
    def initUI(self):
        ''' Создание виджетов и направляющих '''
        layout = QVBoxLayout()

        s_a = QScrollArea(self)

        data = virustotal.get_info_file(self.cur_file)
        if len(data) == 0:
            label = QLabel('Повторите попытку позже..')
            label.setStyleSheet('''
                color: rgba(255, 255, 255, 255);
                border: 2px solid rgba(255, 255, 255, 255);
                border-radius: 15px;
                padding: 15px;
                ''')
            layout.addWidget(label, alignment=Qt.AlignCenter)
        else:
            for name in data:
                result = f'Антивирус: {name}\nРезультат:\n{data[name]["result"]}\n'
                label = QLabel(result)
                label.setStyleSheet('''
                color: rgba(255, 255, 255, 255);
                border: 2px solid rgba(255, 255, 255, 255);
                border-radius: 15px;
                padding: 15px;
                ''')
                layout.addWidget(label, alignment=Qt.AlignCenter)

        # for i in range(100):
        #     label = QLabel(f'Строка номер {i}')
        #     layout.addWidget(label, alignment=Qt.AlignCenter)
        
        content_widget = QWidget()
        content_widget.setLayout(layout)

        s_a.setWidget(content_widget)

        main_layout = QVBoxLayout(self)
        main_layout.addWidget(s_a)


        