import React from 'react'
import { ProductsUriReducerActions, ProductsUriReducerActionType } from '../types'

type FilterPanelProps = {
  dispatchProductsURI: React.Dispatch<ProductsUriReducerActionType>
}

export default function FilterPanel({ dispatchProductsURI }: FilterPanelProps) {
  return (
    <section>
      <section id="filters" data-auto-filter="true">
        <h5 className='accordion-header my-2'>Filters</h5>
        <div className="accordion" id="accordionPanelsStayOpenExample">
          <div className="accordion-item">
            <h2 className="accordion-header" id="panelsStayOpen-headingOne">
              <button className="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="true" aria-controls="panelsStayOpen-collapseOne">
                By Category
              </button>
            </h2>
            <div id="panelsStayOpen-collapseOne" className="accordion-collapse collapse show" aria-labelledby="panelsStayOpen-headingOne">
              <div className="accordion-body">
                <section className="mb-4" data-filter="condition">
                  <div className="form-check mb-3">
                    <input className="form-check-input" type="radio" name="category" id={`categoryradio0`} onClick={() => {
                      // dispatchProductsURI({ type: ProductsUriReducerActions.ResetUriCategory })
                      // dispatchProductsURI({ type: ProductsUriReducerActions.ResetUriSkip })

                      dispatchProductsURI({ type: ProductsUriReducerActions.ResetURI })
                    }} />
                    <label className="form-check-label text-uppercase small" htmlFor={`categoryradio0`}>
                      All
                    </label>
                  </div>
                  {[
                    'automotive', 'fragrances',
                    'furniture', 'groceries',
                    'home-decoration', 'laptops',
                    'lighting', 'mens-shirts',
                    'mens-shoes', 'mens-watches',
                    'motorcycle', 'skincare',
                    'smartphones', 'string',
                    'sunglasses', 'tops',
                    'womens-bags', 'womens-dresses',
                    'womens-jewellery', 'womens-shoes',
                    'womens-watches'
                  ].map((category, i) =>
                    <div key={i} className="form-check mb-3">
                      <input className="form-check-input" type="radio" name="category" id={`categoryradio${i + 1}`} onClick={() => {
                        dispatchProductsURI({ type: ProductsUriReducerActions.SetUriCategory, payload: category })
                        dispatchProductsURI({ type: ProductsUriReducerActions.ResetUriSkip })
                      }} />
                      <label className="form-check-label text-uppercase small" htmlFor={`categoryradio${i + 1}`}>
                        {category}
                      </label>
                    </div>
                  )
                  }
                </section>
              </div>
            </div>
          </div>
          <div className="accordion-item">
            <h2 className="accordion-header" id="panelsStayOpen-headingTwo">
              <button className="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseTwo" aria-expanded="false" aria-controls="panelsStayOpen-collapseTwo">
                By Average Customer Review
              </button>
            </h2>
            <div id="panelsStayOpen-collapseTwo" className="accordion-collapse collapse" aria-labelledby="panelsStayOpen-headingTwo">
              <div className="accordion-body">
                <section className="mb-4">
                  {
                    [4, 3, 2, 1].map((ratings, i) =>
                      <div key={i} className="form-check mb-3">
                        <input className="form-check-input" type="radio" name="rating" id={`ratings-radio${i}`} />
                        <label className="form-check-label small" htmlFor={`ratings-radio${i}`}>
                          {Array(ratings).fill(1).map(() => <i className="fas fa-star text-warning"></i>)} and up
                        </label>
                      </div>
                    )
                  }
                </section>
              </div>
            </div>
          </div>
          <div className="accordion-item">
            <h2 className="accordion-header" id="panelsStayOpen-headingThree">
              <button className="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseThree" aria-expanded="false" aria-controls="panelsStayOpen-collapseThree">
                By Price
              </button>
            </h2>
            <div id="panelsStayOpen-collapseThree" className="accordion-collapse collapse" aria-labelledby="panelsStayOpen-headingThree">
              <div className="accordion-body">
                <section className="mb-4">

                  <div className="form-check mb-3">
                    <input className="form-check-input" type="radio" name="flexRadioDefault" id="price-radio" />
                    <label className="form-check-label text-uppercase small" htmlFor="price-radio">
                      Under $25
                    </label>
                  </div>

                  <div className="form-check mb-3">
                    <input className="form-check-input" type="radio" name="flexRadioDefault" id="price-radio2" />
                    <label className="form-check-label text-uppercase small" htmlFor="price-radio2">
                      $25 to $50
                    </label>
                  </div>

                  <div className="form-check mb-3">
                    <input className="form-check-input" type="radio" name="flexRadioDefault" id="price-radio3" />
                    <label className="form-check-label text-uppercase small" htmlFor="price-radio3">
                      $50 to $100
                    </label>
                  </div>

                  <div className="form-check mb-3">
                    <input className="form-check-input" type="radio" name="flexRadioDefault" id="price-radio4" />
                    <label className="form-check-label text-uppercase small" htmlFor="price-radio4">
                      $100 to $200
                    </label>
                  </div>

                  <div className="form-check mb-3">
                    <input className="form-check-input" type="radio" name="flexRadioDefault" id="price-radio5" />
                    <label className="form-check-label text-uppercase small" htmlFor="price-radio5">
                      $200 &amp; above
                    </label>
                  </div>
                </section>
              </div>
            </div>
          </div>

        </div>


      </section>
    </section>
  )
}
