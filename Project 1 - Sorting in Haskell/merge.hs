module MergeSort where

-- Split the input list into two sublist, returns as tuple
splitHalf :: Ord a => [a] -> ([a], [a])
-- Extract the first mid element from the list to get the first half and drop mid number of element from  the list to get the second half
splitHalf a = (take mid a, drop mid a)
  where 
    -- Compute the middle index of the list
    mid = length a `div` 2

merge :: Ord a => [a] -> [a] -> [a]
--Define base case, in which merging xs with an empty list yields xs
merge xs [] = xs
--Define that when merging an empty list with ys, yields ys
merge [] ys = ys
--when merging x from xs with y from ys 
--guard (logic flow)
--if x <= y         merge x from xs with a recursive call from merge xs with (y:ys)
--otherwise         merge y from ys with a recursive call from merge (x:xs) with ys
merge (x:xs) (y:ys) 
  | x <= y = x:merge xs (y:ys)
  | otherwise = y:merge (x:xs) ys


msort :: Ord a => [a] -> [a]
-- Sorted list of empty list is empty list
msort []  = []
-- Sored list of singleton list is singleton list
msort [x] = [x]
-- Break the list into half and merge the result after sorting left and right half recursively
msort xs  = merge (msort ys) (msort zs)      
  where 
    -- Get the tuple after splitting the list into half
    (ys, zs) = splitHalf xs