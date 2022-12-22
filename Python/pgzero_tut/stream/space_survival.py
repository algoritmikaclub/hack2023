import pgzrun
from random import choice


TITLE = 'SPACE SURVIVAL'
WIDTH = 550
HEIGHT = 861


# Загрузка изображений
bg = Actor('bg_space.png')
astronaut = Actor('astronaut')
ship = Actor('ship')
astronaut.pos = (451, 748)
ship.x, ship.y = (450, 80)

coordinates = [(80, 63), (288, 176), (90, 258), (428, 293),
               (219, 388), (80, 528), (358, 541), (195, 691)]
obstacles = []
for coordinate in coordinates:
    img = choice(['asteroid1', 'asteroid2'])
    obj = Actor(img)
    obj.x = coordinate[0]
    obj.y = coordinate[1]
    obstacles.append(obj)


x, y = 0, 0
game_over = False
win = False

def draw():
    bg.draw()
    if game_over:
        screen.draw.text(f'GAME OVER', center=(WIDTH//2, HEIGHT//2), color='red', fontsize=100)
        return
    if win:
        screen.draw.text(f'ПОБЕДА!', center=(WIDTH//2, HEIGHT//2), color='green', fontsize=100)
        return
    astronaut.draw()
    ship.draw()
    for obstacle in obstacles:
        obstacle.draw()


def update(dt):
    global game_over, win
    astronaut.x += x
    astronaut.y += y
    if astronaut.left < 0:
        astronaut.left = 0
    if astronaut.right > WIDTH:
        astronaut.right = WIDTH
    if astronaut.top < 0:
        astronaut.top = 0
    if astronaut.bottom > HEIGHT:
        astronaut.bottom = HEIGHT
    if astronaut.collidelist(obstacles) != -1:
        game_over = True
    if astronaut.colliderect(ship):
        win = True

def on_key_down(key):
    global x, y
    if key == keys.DOWN:
        y = 0.5
    if key == keys.UP:
        y = -0.5
    if key == keys.LEFT:
        x = -0.5
    if key == keys.RIGHT:
        x = 0.5


pgzrun.go()
