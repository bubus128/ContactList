INSERT INTO public."Contacts"(
	"Id", "FirstName", "LastName", "Password", "CategoryId", "SubcategoryId", "Email", "Phone") 
	VALUES
	
	-- prywatny (no subcategory)
	(gen_random_uuid(), 'Adam', 'Nowak', 'pass1234', '00000000-0000-0000-0000-000000000002', NULL, 'adam.nowak@gmail.com', '123456789'),
	(gen_random_uuid(), 'Ewa', 'Kowalska', 'secret999', '00000000-0000-0000-0000-000000000002', NULL, 'ewa.kowalska@gmail.com', '987654321'),
	(gen_random_uuid(), 'Piotr', 'Wiśniewski', 'hunter88', '00000000-0000-0000-0000-000000000002', NULL, 'piotr.wisniewski@gmail.com', '456789123'),
	(gen_random_uuid(), 'Anna', 'Zielińska', 'password8', '00000000-0000-0000-0000-000000000002', NULL, 'anna.zielinska@gmail.com', '654321987'),
	(gen_random_uuid(), 'Marek', 'Kamiński', 'mypwd2024', '00000000-0000-0000-0000-000000000002', NULL, 'marek.kaminski@gmail.com', '321987654'),
	(gen_random_uuid(), 'Karolina', 'Lewandowska', 'qwerty123', '00000000-0000-0000-0000-000000000002', NULL, 'karolina.lewandowska@gmail.com', '741852963'),
	(gen_random_uuid(), 'Paweł', 'Dąbrowski', 'simple888', '00000000-0000-0000-0000-000000000002', NULL, 'pawel.dabrowski@gmail.com', '963852741'),
	(gen_random_uuid(), 'Magda', 'Wójcik', 'helloPASS', '00000000-0000-0000-0000-000000000002', NULL, 'magda.wojcik@gmail.com', '159753486'),
	(gen_random_uuid(), 'Tomasz', 'Kaczmarek', 'superpass1', '00000000-0000-0000-0000-000000000002', NULL, 'tomasz.kaczmarek@gmail.com', '258369147'),
	(gen_random_uuid(), 'Natalia', 'Mazur', 'bestPASS12', '00000000-0000-0000-0000-000000000002', NULL, 'natalia.mazur@gmail.com', '369147258'),

	-- służbowy (with subcategory)
	(gen_random_uuid(), 'Andrzej', 'Kwiatkowski', 'company777', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000003', 'andrzej.kwiatkowski@gmail.com', '111222333'),
	(gen_random_uuid(), 'Katarzyna', 'Piotrowska', 'workPASS11', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000004', 'katarzyna.piotrowska@gmail.com', '444555666'),
	(gen_random_uuid(), 'Grzegorz', 'Grabowski', 'jobpassword', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000005', 'grzegorz.grabowski@gmail.com', '777888999'),
	(gen_random_uuid(), 'Monika', 'Zając', 'workAcc123', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000004', 'monika.zajac@gmail.com', '112233445'),
	(gen_random_uuid(), 'Robert', 'Pawlak', 'securePASS', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000005', 'robert.pawlak@gmail.com', '556677889'),
	(gen_random_uuid(), 'Joanna', 'Michalska', 'jobjob888', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000003', 'joanna.michalska@gmail.com', '998877665'),
	(gen_random_uuid(), 'Kamil', 'Król', 'corporate9', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000004', 'kamil.krol@gmail.com', '223344556'),
	(gen_random_uuid(), 'Sylwia', 'Wieczorek', 'testPASS22', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000005', 'sylwia.wieczorek@gmail.com', '667788990'),
	(gen_random_uuid(), 'Damian', 'Olszewski', 'passwordOK', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000003', 'damian.olszewski@gmail.com', '445566778'),
	(gen_random_uuid(), 'Alicja', 'Jaworska', 'secure8888', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000004', 'alicja.jaworska@gmail.com', '334455667');