#!/bin/bash
set -e

# Connect to the default database (postgres) and create the pokemon database
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname postgres <<-EOSQL
  CREATE DATABASE pokemon;
EOSQL

# Connect to the pokemon database and create the pokemon table
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname pokemon <<-EOSQL
  CREATE TABLE pokemon (
    id SERIAL PRIMARY KEY,
    abilities TEXT,
    against_bug FLOAT,
    against_dark FLOAT,
    against_dragon FLOAT,
    against_electric FLOAT,
    against_fairy FLOAT,
    against_fight FLOAT,
    against_fire FLOAT,
    against_flying FLOAT,
    against_ghost FLOAT,
    against_grass FLOAT,
    against_ground FLOAT,
    against_ice FLOAT,
    against_normal FLOAT,
    against_poison FLOAT,
    against_psychic FLOAT,
    against_rock FLOAT,
    against_steel FLOAT,
    against_water FLOAT,
    attack INTEGER,
    base_egg_steps INTEGER,
    base_happiness INTEGER,
    base_total INTEGER,
    capture_rate TEXT,
    classfication TEXT,
    defense INTEGER,
    experience_growth BIGINT,
    height_m FLOAT,
    hp INTEGER,
    japanese_name TEXT,
    name TEXT,
    percentage_male FLOAT,
    pokedex_number INTEGER,
    sp_attack INTEGER,
    sp_defense INTEGER,
    speed INTEGER,
    type1 TEXT,
    type2 TEXT,
    weight_kg FLOAT,
    generation INTEGER,
    is_legendary BOOLEAN
  );
EOSQL

# Load data from CSV into the pokemon table
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname pokemon -c "\copy pokemon(abilities, against_bug, against_dark, against_dragon, against_electric, against_fairy, against_fight, against_fire, against_flying, against_ghost, against_grass, against_ground, against_ice, against_normal, against_poison, against_psychic, against_rock, against_steel, against_water, attack, base_egg_steps, base_happiness, base_total, capture_rate, classfication, defense, experience_growth, height_m, hp, japanese_name, name, percentage_male, pokedex_number, sp_attack, sp_defense, speed, type1, type2, weight_kg, generation, is_legendary) FROM '/data/pokemon.csv' DELIMITER ',' CSV HEADER;"
