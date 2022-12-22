import pgzrun
from random import randint


TITLE = 'Alien shooter'
WIDTH = 640
HEIGHT = 415

# load image
alien = Actor('alien')
alien.pos = (300, 200)
aim = Actor('aim')
bg = Actor('bg')

limit = 1.5
time = 0
points = 0


def draw():
    global points
    bg.draw()
    alien.draw()
    aim.draw()
    screen.draw.text(f'Очки {points}', center=(WIDTH//2, 30), color='red', fontsize=60)


def update(dt):
    global time, points, limit
    time += dt
    if time >= limit:
        alien.x = randint(0, WIDTH)
        alien.y = randint(100, HEIGHT)
        time = 0


def on_mouse_down(button, pos):
    global points, limit
    if alien.collidepoint(pos):
        alien.pos = (1000, 1000)
        points += 1
        if points % 5 == 0:
            limit -= 0.1


def on_mouse_move(pos):
    aim.pos = pos


pgzrun.go()
