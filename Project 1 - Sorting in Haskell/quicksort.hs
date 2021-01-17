module QuickSort where

qsort :: Ord a => [a] -> [a]
-- Sorted list of an empty list is empty list
qsort [] = []

-- A sorted list has sublist on the left of the pivot(chosen as the first element) such that all elements on the left is less than or equal to the pivot and it has a sublist on the right of the pivot such that all elements on the right sublist is greater than the pivot. Filter all the elements that are less than pivot to smallerSorted and greater than pivot to biggerSorted.
qsort (x:xs) = smallerSorted ++ [x] ++ biggerSorted
  where smallerSorted = qsort (filter (<=x) xs)
        biggerSorted  = qsort (filter (>x) xs)

--filter p [] = []
--filter p (x:xs) = 
--  if p x   then x : filter p xs
--  else     filter p xs