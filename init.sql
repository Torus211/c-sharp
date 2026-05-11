-- 1. Таблица Клиенты
CREATE TABLE Clients (
    client_id SERIAL PRIMARY KEY,
    client_name VARCHAR(255) NOT NULL,
    address TEXT,
    phone VARCHAR(20)
);

-- 2. Таблица Договоры
CREATE TABLE Contracts (
    contract_id SERIAL PRIMARY KEY,
    client_id INTEGER NOT NULL REFERENCES Clients(client_id) ON DELETE RESTRICT,
    total_contract_amount DECIMAL(15, 2) NOT NULL,
    is_prepaid BOOLEAN NOT NULL DEFAULT FALSE,
    contract_date DATE NOT NULL
);

-- 3. Таблица Товары (в рамках договора)
CREATE TABLE Products (
    product_id SERIAL PRIMARY KEY,
    contract_id INTEGER NOT NULL REFERENCES Contracts(contract_id) ON DELETE CASCADE,
    product_name VARCHAR(255) NOT NULL,
    quantity INTEGER NOT NULL CHECK (quantity > 0),
    unit_price DECIMAL(15, 2) NOT NULL CHECK (unit_price > 0)
);

-- 4. Таблица Оплаты (оплаты по договорам)
CREATE TABLE Payments (
    payment_id SERIAL PRIMARY KEY,
    contract_id INTEGER NOT NULL REFERENCES Contracts(contract_id) ON DELETE CASCADE,
    payment_date DATE NOT NULL,
    amount_paid DECIMAL(15, 2) NOT NULL CHECK (amount_paid > 0),
    payment_method VARCHAR(50)
);

-- 5. Таблица Отгрузки (товарные накладные)
CREATE TABLE Shipments (
    shipment_id SERIAL PRIMARY KEY,
    contract_id INTEGER NOT NULL REFERENCES Contracts(contract_id) ON DELETE CASCADE,
    shipment_date DATE NOT NULL,
    shipped_quantity INTEGER NOT NULL CHECK (shipped_quantity > 0)
);
