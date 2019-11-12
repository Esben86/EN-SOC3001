import bleio
import time
import board
from digitalio import DigitalInOut, Direction

# Kode lånt fra R. Langøy

led = DigitalInOut(board.LED1)
led.direction = Direction.OUTPUT
ledG = DigitalInOut(board.LED2_G)
ledG.direction = Direction.OUTPUT
ledB = DigitalInOut(board.LED2_B)
ledB.direction = Direction.OUTPUT

chara = bleio.Characteristic(bleio.UUID(0xA003),
                             read=True,
                             write=True)

serv = bleio.Service(bleio.UUID(0xA000), [chara])

# Create a peripheral and start it up.
periph = bleio.Peripheral([serv], name="BLEtest")
periph.start_advertising(connectable=True, data=None)

ledB.value = ledG.value = led.value = 1

while not periph.connected:
    ledG.value = 1
    ledB.value = 0  # LED2 lyser Blått
    time.sleep(1)

while periph.connected:
    ledG.value = 0  # LED2 lyser Grønt
    ledB.value = 1

    if (chara.value == bytearray([0x01])):
        led.value = 0
    else:
        led.value = 1
