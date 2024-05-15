import threading

class PooledObject:
    nextID = 0
    lock = threading.Lock()

    def __init__(self):
        with PooledObject.lock:
            self.ID = PooledObject.nextID
            PooledObject.nextID += 1
        self.initialize()

    def operation(self):
        print(f"Об'єкт {self.ID} отримано")

    def initialize(self):
        print(f"Об'єкт {self.ID} ініціалізовано")

class ObjectPool:
    def __init__(self, maxSize):
        self.pool = []
        self.maxSize = maxSize

    def get_max_size(self):
        return self.maxSize

    def acquire_object(self):
        print("Спроба отримати об'єкт з пулу...")
        if self.pool:
            obj = self.pool.pop(0)
            print(f"Об'єкт отримано з пулу. Кількість об'єктів в пулі: {len(self.pool)}")
            return obj
        else:
            new_obj = PooledObject()
            self.maxSize += 1
            print(f"Створено новий об'єкт. Розмір пулу збільшено. Кількість об'єктів в пулі: {len(self.pool)}")
            return new_obj

    def release_object(self, obj):
        if len(self.pool) < self.maxSize:
            self.pool.append(obj)
            print(f"Об'єкт {obj.ID} повернено до пулу. Кількість об'єктів в пулі: {len(self.pool)}")
        else:
            print("Пул заповнено. Неможливо повернути більше об'єктів")

    def get_pool_size(self):
        return len(self.pool)

if __name__ == "__main__":
    pool = ObjectPool(3)
    print("Вміст пулу:", pool.get_pool_size())
    print("Розмір пулу:", pool.get_max_size())

    obj1 = PooledObject()
    obj1.operation()
    obj2 = PooledObject()
    obj2.operation()

    obj3 = PooledObject()
    obj3.operation()

    pool.release_object(obj2)
    pool.release_object(obj1)
    pool.release_object(obj3)

    pool.acquire_object()
    print(pool.get_pool_size())
    pool.acquire_object()
    print(pool.get_pool_size())
    pool.acquire_object()
    print(pool.get_pool_size())
    pool.acquire_object()
    print(pool.get_pool_size())

    pool.release_object(obj1)
    pool.release_object(obj2)
    pool.release_object(obj3)
    print("Розмір пулу:", pool.get_max_size())
