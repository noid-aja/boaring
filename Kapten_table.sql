-- Hapus schema lama beserta seluruh isinya
DROP SCHEMA IF EXISTS kapten CASCADE;

-- Buat schema baru
CREATE SCHEMA kapten;

-- =========================================================
-- TABLE: users
-- =========================================================
CREATE TABLE kapten.users (
    id_user SERIAL PRIMARY KEY,
    nama_lengkap VARCHAR(100) NOT NULL,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    no_telp VARCHAR(20),
    is_aktif BOOLEAN DEFAULT TRUE
);

-- =========================================================
-- TABLE: roles
-- =========================================================
CREATE TABLE kapten.roles (
    id_role SERIAL PRIMARY KEY,
    nama_role VARCHAR(50) NOT NULL UNIQUE
);

-- =========================================================
-- TABLE: user_roles
-- =========================================================
CREATE TABLE kapten.user_roles (
    id_user INT NOT NULL,
    id_role INT NOT NULL,

    PRIMARY KEY (id_user, id_role),

    CONSTRAINT fk_user_roles_user
        FOREIGN KEY (id_user)
        REFERENCES kapten.users(id_user)
        ON DELETE CASCADE,

    CONSTRAINT fk_user_roles_role
        FOREIGN KEY (id_role)
        REFERENCES kapten.roles(id_role)
        ON DELETE CASCADE
);

-- =========================================================
-- TABLE: jenis_kopi
-- =========================================================
CREATE TABLE kapten.jenis_kopi (
    id_jenis SERIAL PRIMARY KEY,
    nama_jenis VARCHAR(50) NOT NULL UNIQUE,
    deskripsi TEXT
);

-- =========================================================
-- TABLE: produk_kopi
-- =========================================================
CREATE TABLE kapten.produk_kopi (
    id_produk SERIAL PRIMARY KEY,
    id_petani INT NOT NULL,
    id_jenis INT NOT NULL,

    nama_produk VARCHAR(100) NOT NULL,
    berat_kg NUMERIC(10,2) NOT NULL,
    harga_pengajuan NUMERIC(12,2) NOT NULL,
    deskripsi TEXT,
    status_produk VARCHAR(30) DEFAULT 'pending_inspeksi',

    CONSTRAINT fk_produk_petani
        FOREIGN KEY (id_petani)
        REFERENCES kapten.users(id_user),

    CONSTRAINT fk_produk_jenis
        FOREIGN KEY (id_jenis)
        REFERENCES kapten.jenis_kopi(id_jenis),

    CONSTRAINT chk_produk_berat
        CHECK (berat_kg > 0),

    CONSTRAINT chk_produk_harga
        CHECK (harga_pengajuan >= 0),

    CONSTRAINT chk_status_produk
        CHECK (status_produk IN (
            'pending_inspeksi',
            'lolos_qc',
            'ditolak_qc',
            'dijadwalkan_lelang',
            'berlangsung',
            'terjual',
            'dibatalkan'
        ))
);

-- =========================================================
-- TABLE: inspeksi
-- =========================================================
CREATE TABLE kapten.inspeksi (
    id_inspeksi SERIAL PRIMARY KEY,
    id_produk INT NOT NULL UNIQUE,
    id_inspektor INT NOT NULL,

    tgl_inspeksi DATE DEFAULT CURRENT_DATE,
    nilai INT NOT NULL,
    grade VARCHAR(10) NOT NULL,
    harga_rekomendasi NUMERIC(12,2) NOT NULL,
    catatan TEXT,
    status_inspeksi VARCHAR(30) NOT NULL,

    CONSTRAINT fk_inspeksi_produk
        FOREIGN KEY (id_produk)
        REFERENCES kapten.produk_kopi(id_produk)
        ON DELETE CASCADE,

    CONSTRAINT fk_inspeksi_inspektor
        FOREIGN KEY (id_inspektor)
        REFERENCES kapten.users(id_user),

    CONSTRAINT chk_nilai_inspeksi
        CHECK (nilai BETWEEN 0 AND 100),

    CONSTRAINT chk_grade_inspeksi
        CHECK (grade IN ('A', 'B', 'C', 'D')),

    CONSTRAINT chk_status_inspeksi
        CHECK (status_inspeksi IN (
            'lolos_qc',
            'ditolak_qc'
        )),

    CONSTRAINT chk_harga_rekomendasi
        CHECK (harga_rekomendasi >= 0)
);

-- =========================================================
-- TABLE: lelang
-- =========================================================
CREATE TABLE kapten.lelang (
    id_lelang SERIAL PRIMARY KEY,
    id_produk INT NOT NULL UNIQUE,

    bid_minimum NUMERIC(12,2) NOT NULL,
    tgl_mulai TIMESTAMP NOT NULL,
    tgl_akhir TIMESTAMP NOT NULL,
    lokasi_lelang VARCHAR(150),
    status_lelang VARCHAR(30) DEFAULT 'dijadwalkan',

    CONSTRAINT fk_lelang_produk
        FOREIGN KEY (id_produk)
        REFERENCES kapten.produk_kopi(id_produk)
        ON DELETE CASCADE,

    CONSTRAINT chk_bid_minimum
        CHECK (bid_minimum >= 0),

    CONSTRAINT chk_tanggal_lelang
        CHECK (tgl_akhir > tgl_mulai),

    CONSTRAINT chk_status_lelang
        CHECK (status_lelang IN (
            'dijadwalkan',
            'berlangsung',
            'selesai',
            'dibatalkan'
        ))
);

-- =========================================================
-- TABLE: bid
-- =========================================================
CREATE TABLE kapten.bid (
    id_bid SERIAL PRIMARY KEY,
    id_lelang INT NOT NULL,
    id_pembeli INT NOT NULL,

    nominal NUMERIC(12,2) NOT NULL,
    tgl_bid TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_bid_lelang
        FOREIGN KEY (id_lelang)
        REFERENCES kapten.lelang(id_lelang)
        ON DELETE CASCADE,

    CONSTRAINT fk_bid_pembeli
        FOREIGN KEY (id_pembeli)
        REFERENCES kapten.users(id_user),

    CONSTRAINT chk_nominal_bid
        CHECK (nominal > 0)
);

-- =========================================================
-- TABLE: pemenang_lelang
-- =========================================================
CREATE TABLE kapten.pemenang_lelang (
    id_pemenang SERIAL PRIMARY KEY,
    id_lelang INT NOT NULL UNIQUE,
    id_bid INT NOT NULL UNIQUE,

    tgl_ditetapkan TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_pemenang_lelang
        FOREIGN KEY (id_lelang)
        REFERENCES kapten.lelang(id_lelang)
        ON DELETE CASCADE,

    CONSTRAINT fk_pemenang_bid
        FOREIGN KEY (id_bid)
        REFERENCES kapten.bid(id_bid)
);

-- =========================================================
-- TABLE: transaksi
-- =========================================================
CREATE TABLE kapten.transaksi (
    id_transaksi SERIAL PRIMARY KEY,
    id_pemenang INT NOT NULL UNIQUE,

    tgl_transaksi TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    total_bayar NUMERIC(12,2) NOT NULL,
    persentase_komisi NUMERIC(5,2) DEFAULT 5.00,
    biaya_komisi NUMERIC(12,2) NOT NULL,
    total_diterima_petani NUMERIC(12,2) NOT NULL,
    status_bayar VARCHAR(30) DEFAULT 'belum_bayar',

    CONSTRAINT fk_transaksi_pemenang
        FOREIGN KEY (id_pemenang)
        REFERENCES kapten.pemenang_lelang(id_pemenang)
        ON DELETE CASCADE,

    CONSTRAINT chk_total_bayar
        CHECK (total_bayar >= 0),

    CONSTRAINT chk_persentase_komisi
        CHECK (persentase_komisi >= 0 AND persentase_komisi <= 100),

    CONSTRAINT chk_biaya_komisi
        CHECK (biaya_komisi >= 0),

    CONSTRAINT chk_total_diterima_petani
        CHECK (total_diterima_petani >= 0),

    CONSTRAINT chk_status_bayar
        CHECK (status_bayar IN (
            'belum_bayar',
            'lunas',
            'dibatalkan'
        ))
);

-- =========================================================
-- SEED DATA: roles
-- =========================================================
INSERT INTO kapten.roles (id_role, nama_role) VALUES
(1, 'admin'),
(2, 'petani'),
(3, 'pembeli'),
(4, 'inspektor');

-- =========================================================
-- SEED DATA: users
-- =========================================================
INSERT INTO kapten.users
(id_user, nama_lengkap, username, password, no_telp, is_aktif)
VALUES
(1, 'Admin', 'admin', 'admin123', '081111111111', TRUE),
(2, 'Pak Budi', 'budi', 'budi123', '082222222222', TRUE),
(3, 'Bu Sari', 'sari', 'sari123', '083333333333', TRUE),
(4, 'Pak Joko', 'joko', 'joko123', '084444444444', TRUE),
(5, 'CV Kopi Makmur', 'makmur', 'makmur123', '085555555555', TRUE),
(6, 'Rina QC', 'rinaqc', 'rina123', '086666666666', TRUE);

-- =========================================================
-- SEED DATA: user_roles
-- =========================================================
INSERT INTO kapten.user_roles (id_user, id_role) VALUES
(1, 1), -- Admin = admin
(2, 2), -- Pak Budi = petani
(3, 2), -- Bu Sari = petani
(4, 3), -- Pak Joko = pembeli
(5, 3), -- CV Kopi Makmur = pembeli
(6, 4); -- Rina QC = inspektor

-- =========================================================
-- SEED DATA: jenis_kopi
-- =========================================================
INSERT INTO kapten.jenis_kopi
(id_jenis, nama_jenis, deskripsi)
VALUES
(1, 'Arabika', 'Jenis kopi arabika'),
(2, 'Robusta', 'Jenis kopi robusta'),
(3, 'Liberika', 'Jenis kopi liberika');

-- =========================================================
-- SEED DATA: produk_kopi
-- Produk masih pending inspeksi.
-- Belum masuk lelang.
-- =========================================================
INSERT INTO kapten.produk_kopi
(id_produk, id_petani, id_jenis, nama_produk, berat_kg, harga_pengajuan, deskripsi, status_produk)
VALUES
(1, 2, 1, 'Kopi Arabika Gayo', 25.00, 1200000, 'Kopi arabika dari petani Pak Budi', 'pending_inspeksi'),
(2, 2, 2, 'Kopi Robusta Lampung', 40.00, 1600000, 'Kopi robusta hasil panen terbaru', 'pending_inspeksi'),
(3, 3, 1, 'Kopi Arabika Kintamani', 30.00, 1500000, 'Kopi arabika dari petani Bu Sari', 'pending_inspeksi'),
(4, 3, 3, 'Kopi Liberika Riau', 20.00, 900000, 'Kopi liberika kualitas lokal', 'pending_inspeksi');

-- =========================================================
-- CEK DATA
-- =========================================================
SELECT * FROM kapten.users;
SELECT * FROM kapten.roles;
SELECT * FROM kapten.user_roles;
SELECT * FROM kapten.jenis_kopi;
SELECT * FROM kapten.produk_kopi;
SELECT * FROM kapten.inspeksi;
SELECT * FROM kapten.lelang;
SELECT * FROM kapten.bid;
SELECT * FROM kapten.pemenang_lelang;