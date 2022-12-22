import React, { useCallback } from 'react'
import { ProductsUriReducerActions, ProductsUriReducerActionType } from '../types'

type SortPanelProps = {
  dispatchProductsURI: React.Dispatch<ProductsUriReducerActionType>
}

export default function SortPanel({ dispatchProductsURI }: SortPanelProps) {
  const handleChange = useCallback(
    (e: any) => {
      if (e.target.value === 'priceAscending') {
        dispatchProductsURI({ type: ProductsUriReducerActions.SortByPriceAscending })
      } else if (e.target.value === 'priceDescending') {
        dispatchProductsURI({ type: ProductsUriReducerActions.SortByPriceDescending })
      } else if (e.target.value === 'ratingDescending') {
        dispatchProductsURI({ type: ProductsUriReducerActions.SortByRatingDescending })
      }
    },
    [],
  )
  return (
    <>
      <div className="row justify-content-center">
        <div className="col-md-6 my-auto py-3">
          <div id="select-wrapper-956232" className="select-wrapper">
            <select defaultValue="placeholder" className="form-select" aria-label="Default select example" onChange={handleChange}>
              <option disabled={true} value="placeholder">Select sorting order</option>
              <option value="ratingDescending">Best Rating</option>
              <option value="priceAscending">Lowest price first</option>
              <option value="priceDescending">Highest price first</option>
            </select>
          </div>
        </div>
      </div>
    </>
  )
}
