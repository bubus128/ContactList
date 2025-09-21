INSERT INTO public."Contacts"(
    "Id", "FirstName", "LastName", "Password", "CategoryId", "SubcategoryId", "Email", "Phone", "Birthday")
VALUES
    -- prywatny (no subcategory)
    (gen_random_uuid(), 'Adam', 'Nowak', 'pass1234', '00000000-0000-0000-0000-000000000002', NULL, 'adam.nowak@gmail.com', '123456789', '1990-01-15'),
    (gen_random_uuid(), 'Ewa', 'Kowalska', 'secret999', '00000000-0000-0000-0000-000000000002', NULL, 'ewa.kowalska@gmail.com', '987654321', '1988-06-22'),
    (gen_random_uuid(), 'Piotr', 'Wiśniewski', 'hunter88', '00000000-0000-0000-0000-000000000002', NULL, 'piotr.wisniewski@gmail.com', '456789123', '1992-11-05'),
    (gen_random_uuid(), 'Anna', 'Zielińska', 'password8', '00000000-0000-0000-0000-000000000002', NULL, 'anna.zielinska@gmail.com', '654321987', '1991-03-30'),
    (gen_random_uuid(), 'Marek', 'Kamiński', 'mypwd2024', '00000000-0000-0000-0000-000000000002', NULL, 'marek.kaminski@gmail.com', '321987654', '1989-09-12'),
    (gen_random_uuid(), 'Karolina', 'Lewandowska', 'qwerty123', '00000000-0000-0000-0000-000000000002', NULL, 'karolina.lewandowska@gmail.com', '741852963', '1993-07-08'),
    (gen_random_uuid(), 'Paweł', 'Dąbrowski', 'simple888', '00000000-0000-0000-0000-000000000002', NULL, 'pawel.dabrowski@gmail.com', '963852741', '1990-12-01'),
    (gen_random_uuid(), 'Magda', 'Wójcik', 'helloPASS', '00000000-0000-0000-0000-000000000002', NULL, 'magda.wojcik@gmail.com', '159753486', '1994-02-14'),
    (gen_random_uuid(), 'Tomasz', 'Kaczmarek', 'superpass1', '00000000-0000-0000-0000-000000000002', NULL, 'tomasz.kaczmarek@gmail.com', '258369147', '1987-10-19'),
    (gen_random_uuid(), 'Natalia', 'Mazur', 'bestPASS12', '00000000-0000-0000-0000-000000000002', NULL, 'natalia.mazur@gmail.com', '369147258', '1991-05-25'),

    -- służbowy (with subcategory)
    (gen_random_uuid(), 'Andrzej', 'Kwiatkowski', 'company777', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000003', 'andrzej.kwiatkowski@gmail.com', '111222333', '1985-08-12'),
    (gen_random_uuid(), 'Katarzyna', 'Piotrowska', 'workPASS11', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000004', 'katarzyna.piotrowska@gmail.com', '444555666', '1986-03-04'),
    (gen_random_uuid(), 'Grzegorz', 'Grabowski', 'jobpassword', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000005', 'grzegorz.grabowski@gmail.com', '777888999', '1984-07-20'),
    (gen_random_uuid(), 'Monika', 'Zając', 'workAcc123', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000004', 'monika.zajac@gmail.com', '112233445', '1990-11-11'),
    (gen_random_uuid(), 'Robert', 'Pawlak', 'securePASS', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000005', 'robert.pawlak@gmail.com', '556677889', '1989-01-27'),
    (gen_random_uuid(), 'Joanna', 'Michalska', 'jobjob888', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000003', 'joanna.michalska@gmail.com', '998877665', '1992-04-16'),
    (gen_random_uuid(), 'Kamil', 'Król', 'corporate9', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000004', 'kamil.krol@gmail.com', '223344556', '1988-09-05'),
    (gen_random_uuid(), 'Sylwia', 'Wieczorek', 'testPASS22', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000005', 'sylwia.wieczorek@gmail.com', '667788990', '1991-06-30'),
    (gen_random_uuid(), 'Damian', 'Olszewski', 'passwordOK', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000003', 'damian.olszewski@gmail.com', '445566778', '1987-12-14'),
    (gen_random_uuid(), 'Alicja', 'Jaworska', 'secure8888', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000004', 'alicja.jaworska@gmail.com', '334455667', '1993-08-22');