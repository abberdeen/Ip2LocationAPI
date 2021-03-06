PGDMP     $                    x            Hybrid    12.1    12.1                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            	           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            
           1262    16393    Hybrid    DATABASE     �   CREATE DATABASE "Hybrid" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_United States.1252' LC_CTYPE = 'English_United States.1252';
    DROP DATABASE "Hybrid";
                postgres    false            �            1259    16413 	   Addresses    TABLE     P  CREATE TABLE public."Addresses" (
    geoname_id integer NOT NULL,
    locale_code character varying(2),
    continent_code character varying(4),
    continent_name character varying(32),
    country_iso_code character varying(4),
    country_name character varying(64),
    subdivision_1_iso_code character varying(4),
    subdivision_1_name character varying(64),
    subdivision_2_iso_code character varying(4),
    subdivision_2_name character varying(64),
    city_name character varying(64),
    metro_code character(8),
    time_zone character(32),
    is_in_european_union boolean
);
    DROP TABLE public."Addresses";
       public         heap    postgres    false            �            1259    16406    Geolocations    TABLE     �  CREATE TABLE public."Geolocations" (
    network inet DEFAULT '192.168.1.1'::inet NOT NULL,
    geoname_id integer,
    registered_country_geoname_id integer,
    represented_country_geoname_id character varying(10),
    is_anonymous_proxy smallint,
    is_satellite_provider integer,
    postal_code character varying(10),
    latitude double precision,
    longitude double precision,
    accuracy_radius integer
);
 "   DROP TABLE public."Geolocations";
       public         heap    postgres    false            �
           2606    24669    Geolocations Geolocations_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public."Geolocations"
    ADD CONSTRAINT "Geolocations_pkey" PRIMARY KEY (network);
 L   ALTER TABLE ONLY public."Geolocations" DROP CONSTRAINT "Geolocations_pkey";
       public            postgres    false    202            �
           2606    16417    Addresses LocationsEn_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."Addresses"
    ADD CONSTRAINT "LocationsEn_pkey" PRIMARY KEY (geoname_id);
 H   ALTER TABLE ONLY public."Addresses" DROP CONSTRAINT "LocationsEn_pkey";
       public            postgres    false    203           