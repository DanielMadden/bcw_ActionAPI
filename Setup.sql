USE boisecodeworks;

DROP TABLE bids;

-- DROP TABLE items;

-- CREATE TABLE items
-- (
--   id INT AUTO_INCREMENT,
--   title VARCHAR(255),
--   price INT,
--   sold TINYINT,

--   PRIMARY KEY(id)
-- );

-- CREATE TABLE members
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255),

--   PRIMARY KEY(id)
-- );

CREATE TABLE bids
(
  id INT AUTO_INCREMENT,
  itemId INT,
  memberId INT,
  amount INT,

  PRIMARY KEY(id),

  FOREIGN KEY(itemId)
    REFERENCES items (id)
    ON DELETE CASCADE,

  FOREIGN KEY(memberId)
    REFERENCES members (id)
    ON DELETE CASCADE
)