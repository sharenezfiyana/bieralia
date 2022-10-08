CREATE DATABASE Bieralia
GO
USE Bieralia
GO
CREATE TABLE [User](
	UserID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
    Username VARCHAR(255) NOT NULL,
    DOB DATE,
    [Password] VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	[Address] VARCHAR(255),
	[Status] CHAR(1) NOT NULL
)

CREATE TABLE [Admin](
	UserID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
    Username VARCHAR(255) NOT NULL,
    DOB DATE,
    [Password] VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	[Address] VARCHAR(255),
	[Status] CHAR(1) NOT NULL
)

CREATE TABLE Book(
	BookID CHAR(14) PRIMARY KEY,
	BookTitle VARCHAR(255) NOT NULL,
	BookDesc TEXT NOT NULL,
	Author VARCHAR(255),
	Quantity INT NOT NULL,
	[Image] VARCHAR(255),
	Price INT NOT NULL,
	[Status] CHAR(1) NOT NULL default 'A'
)

CREATE TABLE [Transaction](
	TransactionID VARCHAR(20) PRIMARY KEY,
	[Status] VARCHAR(20) NOT NULL,
	UserID UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES [User](UserID) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE TransactionDetail(
	TransactionDetailID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	TransactionID VARCHAR(20) FOREIGN KEY REFERENCES [Transaction](TransactionID) ON DELETE CASCADE ON UPDATE CASCADE,
	BookID CHAR(14) NOT NULL FOREIGN KEY REFERENCES Book(BookID) ON DELETE CASCADE ON UPDATE CASCADE,
	Quantity INT NOT NULL
)

insert into [Admin] (Username, DOB, [Password], Email, PhoneNumber, [Address], [Status]) VALUES
('sharen', '2002-12-10', 'admin', 'sharen@bieralia.com', '081234567890', 'Jakarta', 'A')

insert into [Admin] (Username, DOB, [Password], Email, PhoneNumber, [Address], [Status]) VALUES
('admin', '2002-12-10', 'admin', 'admin@bieralia.com', '08129301293', 'Jakarta', 'A')

SELECT * FROM Book

INSERT INTO [Book] VALUES
('20220701230416','Pachinko (National Book Award Finalist)','A New York Times Top Ten Book of the Year and National Book Award finalist, Pachinko is an extraordinary epic of four generations of a poor Korean immigrant family as they fight to control their destiny in 20th-century Japan (San Francisco Chronicle ). ','Lee, Min Jin',10,'20220701230416.jpg',313000,'A'),
('20220701230458','Portrait of a Thief','The thefts are engaging and surprising, and the narrative brims with international intrigue. Li, however, has delivered more than a straight thriller here, especially in the parts that depict the despair Will and his pals feel at being displaced, overlooked, underestimated and discriminated against. ','Li, Grace D.',10,'20220701230458.jpg',210000,'A'),
('20220701230534','Interior Chinatown','NEW YORK TIMES BESTSELLER - NATIONAL BOOK AWARD WINNER - From the infinitely inventive author of How to Live Safely in a Science Fictional Universe, a deeply personal novel about race, pop culture, immigration, assimilation, and escaping the roles we are forced to play. One of the funniest books of the year. ','Yu, Charles',10,'20220701230534.jpg',103000,'A'),
('20220701230621','Homicide and Halo-Halo','Death at a beauty pageant turns Tita Rosies Kitchen upside down in the latest entry of this witty and humorous cozy mystery series by Mia P. Manansala. Things are heating up for Lila Macapagal.  ','Manansala, Mia P. ',10,'20220701230621.jpg',216000,'A'),
('20220701230647','Fiona and Jane','A VULTURE BEST BOOK OF THE YEAR (SO FAR) Hos debut work is the perfect modern example of great American fiction. . . . You will love it. --Jake Tapper Intimate, cinematic. . . . The world Ho creates between the two women feels like one friend reading the others story, wishing she were there.','Ho, Jean Chen ',10,'20220701230647.jpg',498000,'A'),
('20220701230718','Arsenic and Adobo','A RUSA Award-winning novel! The first book in a new culinary cozy series full of sharp humor and delectable dishes--one that might just be killer.... When Lila Macapagal moves back home to recover from a horrible breakup, her life seems to be following all the typical rom-com tropes. ','Manansala, Mia P.',10,'20220701230718.jpg',910000,'A'),
('20220701230842','The Last Story of Mina Lee','strong A REESES BOOK CLUB PICK strong br br strong INSTANT NEW YORK TIMES BESTSELLER strong br br strong Riveting and unconventional, The Last Story of Mina Lee traces the far-reaching consequences of secrets in the lives of a Korean immigrant mother and her daughter strong br br Margot Les mother is ignoring her calls. ','Kim, Nancy Jooyoun',10,'20220701230842.jpg',890000,'A'),
('20220701230904','Dial a for Aunties','Sutanto brilliantly infuses comedy and culture into the unpredictable rom-com murder mystery mashup as Meddy navigates familial duty, possible arrest and a groomzilla.laughed out loud and you will too."--USA Today (four-star review) "A hilarious, heartfelt romp of a novel about--what else?','Sutanto, Jesse Q.',10,'20220701230904.jpg',829999,'A'),
('20220701230939','Peach Blossom Spring','A "beautifully rendered" novel about war, migration, and the power of telling our stories, Peach Blossom Spring follows three generations of a Chinese family on their search for a place to call home (Georgia Hunter, New York Times bestselling author). "Within every misfortune there is a blessing and within every blessing, the seeds of misfortune, and so it goes, until the end of time." ','Fu, Melissa',10,'20220701230939.jpg',278900,'A'),
('20220701231040','The Tea Girl of Hummingbird Lane','From #1 New York Times bestselling author Lisa See, "one of those special writers capable of delivering both poetry and plot" (The New York Times Book Review ), a moving novel about tradition, tea farming, and the bonds between mothers','See, Lisa',10,'20220701231040.jpg',781999,'A'),
('20220701231105','Crazy Rich Asians','A hilarious and heartwarming New York Times bestselling novel--the basis for the acclaimed major motion picture Theres rich, theres filthy rich, and then theres crazy rich ... A Pride and Prejudice -like send-up about an heir bringing his Chinese-American girlfriend home to meet his ancestor-obsessed family."','Kwan, Kevin ',10,'20220701231105.jpg',738999,'A'),
('20220701231137','Nuclear Family','Set in the months leading up to the 2018 nuclear missile false alarm, a Korean American family living in Hawaii faces the fallout of their eldest sons attempt to run across the Demilitarized Zone into North Korea in this fresh, inventive, and at times, hilarious novel (Kaui Hart Hemmings, author of The Descendants ) ','Han, Joseph',10,'20220701231137.jpg',192000,'A'),
('20220701231224','Where the Sun Rises: Volume 2','The From Kona with Love series depicts multicultural romance, love, loss, and redemption woven into a family saga, set in the beautiful islands of Hawaii. Though interconnected, each installment can be read as a standalone. When Maele Moana is paired up with Adam Yates to walk down the aisle together at her friend Andies wedding, it isnt exactly a perfect match. Maele is the daughter of a plantation worker, and Adam is the son of one of the richest men in Oahu. ','Gomez',10,'20220701231224.jpg',689000,'A'),
('20220701231248','Land of Big Numbers: Stories','strong A Best Book of the Year: Barack Obama - NPR - The Washington Post - The Philadelphia Inquirer - Esquire - Kirkus Reviews - Chicago Public Library - Electric Literature strong strong Malala Yousafzais Fearless Book Club Pick for Literati strong strong Dazzling','Chen, Te-Ping',10,'20220701231248.jpg',437899,'A'),
('20220701231313','My Year Abroad','INSTANT NATIONAL BESTSELLER A New York Times Notable Book * Named a Best Book of the Year by Vogue , TIME , and Marie Claire "A manifesto to happiness--the one found when you stop running from who you are."','Lee, Chang-Rae',10,'20220701231313.jpg',271999,'A');

