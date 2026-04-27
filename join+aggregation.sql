-- Task1
SELECT f.title, c.name AS category_name
FROM film f
JOIN film_category fc ON f.film_id = fc.film_id
JOIN category c ON fc.category_id = c.category_id
ORDER BY f.title ASC
LIMIT 20;


-- Task2
SELECT first_name, last_name, email
FROM customer
WHERE email LIKE '%@sakilacustomer.org'
ORDER BY last_name;


-- Task3
SELECT rating, COUNT(*) AS film_count
FROM film
GROUP BY rating
ORDER BY film_count DESC;


-- Task4
SELECT 
    CONCAT(a.first_name, ' ', a.last_name) AS full_name, 
    COUNT(f.film_id) AS film_count
FROM actor a
JOIN film_actor fa ON a.actor_id = fa.actor_id
JOIN film f ON fa.film_id = f.film_id
GROUP BY a.actor_id, a.first_name, a.last_name
ORDER BY film_count DESC
LIMIT 10;


--Task5
SELECT 
    CONCAT(c.first_name, ' ', c.last_name) AS full_name, 
    ROUND(SUM(p.amount), 2) AS total_paid
FROM customer c
JOIN payment p ON c.customer_id = p.customer_id
JOIN rental r ON p.rental_id = r.rental_id
GROUP BY c.customer_id, c.first_name, c.last_name
HAVING SUM(p.amount) > 150
ORDER BY total_paid DESC;
