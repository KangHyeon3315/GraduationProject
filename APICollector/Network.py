import threading
import socket
import psutil
import datetime
import os
import time


class Network:
    def __init__(self, Task):
        self.addr = ("127.0.0.1", 7000)

        self.receiveQueue = []

        try:
            self.sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            self.sock.connect(self.addr)

            self.Send("Role;{}".format(Task))

            th = threading.Thread(target=self.Receive)
            th.start()

        except:
            self.sock = None

    def Requests(self, msg):
        self.RequestsData(msg)

        repeat = 0
        while True:
            repeat += 1
            if repeat >= 20:
                self.RequestsData(msg)
                repeat = 0

            if len(self.receiveQueue) > 0:
                if self.receiveQueue[0].split(";")[0] == msg:
                    data = self.receiveQueue[0]
                    self.receiveQueue = self.receiveQueue[1:]
                    return data
                else:
                    self.receiveQueue.append(self.receiveQueue[0])
                    self.receiveQueue = self.receiveQueue[1:]
            time.sleep(0.2)

    def RequestsData(self, msg):
        send_msg = "Requests;{}".format(msg)

        try:
            if self.sock is not None:
                self.Send(send_msg)

        except:
            pass

    def Log(self, msg):
        send_msg = "log;{}".format(msg)

        try:
            if self.sock is not None:
                self.Send(send_msg)

        except:
            pass

    def Company(self, company):
        send_msg = "Company;{}".format(company)

        try:
            if self.sock is not None:
                self.Send(send_msg)

        except:
            pass

    def CompanyCount(self, count):
        send_msg = "CompanyCount;{}".format(count)

        try:
            if self.sock is not None:
                self.Send(send_msg)

        except:
            pass

    def CompleteCount(self, count):
        send_msg = "CompleteCount;{}".format(count)

        try:
            if self.sock is not None:
                self.Send(send_msg)

        except:
            pass

    def Work(self, msg):
        send_msg = "work;{}".format(msg)

        try:
            if self.sock is not None:
                self.Send(send_msg)

        except:
            pass

    def RqCount(self, rqcount):
        send_msg = "RqCount;{}".format(rqcount)

        try:
            if self.sock is not None:
                self.Send(send_msg)

        except:
            pass

    def Exception(self, ex):
        send_msg = "Exception;{}".format(ex)

        try:
            if self.sock is not None:

                self.Send(send_msg)

        except:
            pass

    def Send(self, msg):
        print(msg)
        msg = "{};".format(msg)
        try:
            data = msg.encode()

            length = len(data)

            self.sock.sendall(length.to_bytes(4, byteorder="big"))

            self.sock.sendall(data)
        except:
            pass


    def Receive(self):
        try:
            while True:
                data = self.sock.recv(4)

                length = int.from_bytes(data, "big")

                if length == 0:
                    continue

                data = self.sock.recv(length + 1)

                msg = data.decode()

                print("Receive Msg : {}".format(msg))
                self.receiveQueue.append(msg)
        except:
            pass

if __name__ == "__main__":
    net = Network()