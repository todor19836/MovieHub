INSERT INTO Movies (Title, Genre, [Year], Rating, Description, ImageUrl)
VALUES
-- Action
('The Dark Knight', 'Action', 2008, 9.0, 'Batman faces the Joker in Gotham City.', 'https://m.media-amazon.com/images/I/51k0qa8y-hL._AC_.jpg'),
('Avengers: Endgame', 'Action', 2019, 8.4, 'The Avengers try to reverse the damage caused by Thanos.', 'https://m.media-amazon.com/images/I/81ExhpBEbHL._AC_SY679_.jpg'),
('John Wick', 'Action', 2014, 7.4, 'A retired hitman returns to action after a personal loss.', 'https://m.media-amazon.com/images/I/81F5PF9oHhL._AC_SY679_.jpg'),
('Mad Max: Fury Road', 'Action', 2015, 8.1, 'A post-apocalyptic chase across the desert.', 'https://m.media-amazon.com/images/I/81p+xe8cbnL._AC_SY679_.jpg'),
('Gladiator', 'Action', 2000, 8.5, 'A Roman general becomes a gladiator and seeks revenge.', 'https://m.media-amazon.com/images/I/51A9g3ZzpWL._AC_.jpg'),

-- Sci-Fi
('Inception', 'Sci-Fi', 2010, 8.8, 'A thief enters people dreams to steal secrets.', 'https://m.media-amazon.com/images/I/81p+xe8cbnL._AC_SY679_.jpg'),
('Interstellar', 'Sci-Fi', 2014, 8.7, 'A team travels through a wormhole in space.', 'https://m.media-amazon.com/images/I/91kFYg4fX3L._AC_SY679_.jpg'),
('The Matrix', 'Sci-Fi', 1999, 8.7, 'A hacker discovers the truth about his reality.', 'https://m.media-amazon.com/images/I/51EG732BV3L.jpg'),
('Avatar', 'Sci-Fi', 2009, 7.9, 'A marine explores the alien world of Pandora.', 'https://m.media-amazon.com/images/I/71k8F3Q4oML._AC_SY679_.jpg'),
('Blade Runner 2049', 'Sci-Fi', 2017, 8.0, 'A young blade runner uncovers a dangerous secret.', 'https://m.media-amazon.com/images/I/71K5pKf6VQL._AC_SY679_.jpg'),

-- Comedy
('Home Alone', 'Comedy', 1990, 7.7, 'A young boy protects his house from burglars.', 'https://m.media-amazon.com/images/I/71v4O3R2YKL._AC_SY679_.jpg'),
('The Mask', 'Comedy', 1994, 6.9, 'A shy man finds a magical mask that changes his life.', 'https://m.media-amazon.com/images/I/51zUbui+gbL._AC_.jpg'),
('Mr. Bean''s Holiday', 'Comedy', 2007, 6.4, 'Mr. Bean goes on a chaotic holiday in France.', 'https://m.media-amazon.com/images/I/51P6DNQ0KDL._AC_.jpg'),
('The Hangover', 'Comedy', 2009, 7.7, 'Friends try to remember what happened after a wild night.', 'https://m.media-amazon.com/images/I/51+8zQJzYSL._AC_.jpg'),
('Jumanji: Welcome to the Jungle', 'Comedy', 2017, 6.9, 'Teenagers are trapped inside a dangerous video game.', 'https://m.media-amazon.com/images/I/81Qf3D7y+TL._AC_SY679_.jpg'),

-- Drama
('The Shawshank Redemption', 'Drama', 1994, 9.3, 'Two prisoners form a powerful friendship over many years.', 'https://m.media-amazon.com/images/I/51NiGlapXlL._AC_.jpg'),
('Forrest Gump', 'Drama', 1994, 8.8, 'A kind man lives through important moments in history.', 'https://m.media-amazon.com/images/I/61Kc0A6P1RL._AC_SY679_.jpg'),
('Joker', 'Drama', 2019, 8.4, 'A troubled man slowly becomes Gotham famous villain.', 'https://m.media-amazon.com/images/I/71KPOvu-hOL._AC_SY679_.jpg'),
('The Green Mile', 'Drama', 1999, 8.6, 'A prison guard meets a mysterious prisoner with a gift.', 'https://m.media-amazon.com/images/I/51mvLqoD0qL._AC_.jpg'),
('Fight Club', 'Drama', 1999, 8.8, 'An unhappy man becomes involved in an underground fight club.', 'https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg'),

-- Horror
('The Conjuring', 'Horror', 2013, 7.5, 'Paranormal investigators help a family haunted by dark forces.', 'https://m.media-amazon.com/images/I/81Y7S1VQ5RL._AC_SY679_.jpg'),
('It', 'Horror', 2017, 7.3, 'A group of children face a terrifying evil clown.', 'https://m.media-amazon.com/images/I/71aLultW5EL._AC_SY679_.jpg'),
('A Quiet Place', 'Horror', 2018, 7.5, 'A family must live in silence to survive mysterious creatures.', 'https://m.media-amazon.com/images/I/81xA0JXn0hL._AC_SY679_.jpg'),
('The Ring', 'Horror', 2002, 7.1, 'A cursed videotape brings deadly consequences.', 'https://m.media-amazon.com/images/I/51I9UZRjDWL._AC_.jpg'),
('Insidious', 'Horror', 2010, 6.8, 'A family tries to save their son from a dark spiritual world.', 'https://m.media-amazon.com/images/I/51N6Z0G5VFL._AC_.jpg'),

-- Romance
('Titanic', 'Romance', 1997, 7.9, 'A love story aboard the Titanic.', 'https://m.media-amazon.com/images/I/71rNJQ2g-EL._AC_SY679_.jpg'),
('The Notebook', 'Romance', 2004, 7.8, 'A romantic story about love that lasts for years.', 'https://m.media-amazon.com/images/I/51R7A6KX6DL._AC_.jpg'),
('La La Land', 'Romance', 2016, 8.0, 'A musician and an actress fall in love while chasing dreams.', 'https://m.media-amazon.com/images/I/81uQ2jC5L9L._AC_SY679_.jpg'),
('Me Before You', 'Romance', 2016, 7.4, 'A young woman forms a deep bond with a paralyzed man.', 'https://m.media-amazon.com/images/I/81gF6YJbWCL._AC_SY679_.jpg'),
('Pride and Prejudice', 'Romance', 2005, 7.8, 'A classic romantic story about love and social class.', 'https://m.media-amazon.com/images/I/51T8OXMiB5L._AC_.jpg');