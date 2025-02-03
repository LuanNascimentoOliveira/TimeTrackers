CREATE TABLE timebank (
    timebankId INT AUTO_INCREMENT PRIMARY KEY,
    dateTimeBank DATETIME NOT NULL,
    startTimebank VARCHAR(10) NOT NULL,
    break VARCHAR(10) NOT NULL,
    clockin VARCHAR(10) NOT NULL,
    clockout VARCHAR(10) NOT NULL,
    description VARCHAR(200) NOT NULL
);

INSERT INTO timebank (dateTimeBank, startTimebank, break, clockin, clockout, description) VALUES
                                                                                              ('2024-09-01', "09:00", "12:00", "13:00", "18:00", 'Trabalho de exemplo 1');
