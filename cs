
import socket
from random import randint, shuffle
import time

m = 2**10
M = 2**16

# Replace the line below with the octets of the target IP
database = [34, 201, 4, 22]

database_str = '.'.join(list(map(str, database)))

output = open('db.csv', 'w+')

def healthcheck(p):
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock.settimeout(1)
    result = sock.connect_ex((database_str, p))
    if result == 0:
        output.write(f'{p} OP\n')
    output.flush()
    sock.close()

K = list(range(m, M))
shuffle(K)

for x in K:
    healthcheck(x)
    time.sleep(randint(1,3)/10.0)
