import React from 'react'
import { Col, Row, Container } from 'react-bootstrap'
import { addToRemoteCart, removeOneFromRemoteCart } from '../util/serverCart'
import { AiOutlineArrowUp, AiOutlineArrowDown } from 'react-icons/ai'
import StarRating from './StarRating'
import './ProductCard.css'
import { Product } from '../types'

type ProductCardProps = {
  p: Product,
  dispatchCart: React.Dispatch<{
    type: any;
    payload: any;
  }>,
  cart: any[]
}

const ProductCard = ({ p, dispatchCart, cart }: ProductCardProps) => {
  return (
    <>
      <div className="col">
        <div className="card shadow-0 border rounded-3">
          <div className="card-body">
            <div className="row">
              <div className="col-md-12 col-lg-3 col-xl-3 mb-4 mb-lg-0">
                <div className="bg-image hover-zoom ripple rounded ripple-surface" >
                  {/* <img src={p.thumbnail} className="img-fluid" alt="product image" /> */}
                  <img src={p.imageUrl} style={{ 'width': 130, 'aspectRatio': 4 / 3 }} alt="product image" />
                  {/* <img src={p.thumbnail} style={{ "objectFit": "contain" }} alt="product image" /> */}
                  {/* className="w-100" /> */}
                  <a href="#!">
                    <div className="hover-overlay">
                      <div className="mask" style={{ backgroundColor: 'rgba(253, 253, 253, 0.15)' }}></div>
                    </div>
                  </a>
                </div>
              </div>
              <div className="col-md-6 col-lg-6 col-xl-6">
                <h5 className='mb-0'>{p.title}</h5>
                <div className="mt-0 mb-1 text-muted small">
                  <span>Category</span>
                  <span className="text-primary"> - </span>
                  <span>{p.category}</span>
                </div>
                <div className="d-flex flex-row">
                  <div className="text-danger mb-1 me-2">
                    <StarRating
                      count={5}
                      size={30}
                      value={p.rating}
                      activeColor={'red'}
                      inactiveColor={'#ddd'} />
                  </div>
                </div>
                {/* <div className="mb-2 text-muted small">
                  <span>Unique design</span>
                  <span className="text-primary"> • </span>
                  <span>For men</span>
                  <span className="text-primary"> • </span>
                  <span>Casual<br /></span>
                </div> */}
                <p className="text-truncate mb-4 mb-md-0">
                  {p.description}
                </p>
              </div>
              <div className="col-md-6 col-lg-3 col-xl-3 border-sm-start-none border-start">
                <div className="d-flex flex-row align-items-center mb-1">
                  {/* <h4 className="mb-1 me-1">${parseFloat(p.price * (1 - p.discountPercentage / 100)).toFixed(2)}</h4> */}
                  <h4 className="mb-1 me-1">${(p.price * (1 - p.discountPercentage / 100)).toFixed(2)}</h4>
                  <span className="text-danger"><s>${p.price}</s></span>
                </div>
                <h6 className="text-success">Free shipping</h6>
                <Container fluid>
                  <Row className='justify-content-end'>
                    <Col>
                      <Row className="d-flex justify-content-center">
                        <Col className='px-0 d-flex justify-content-end'>
                          <button className="btn-success btn-md" onClick={() => {
                            dispatchCart({ type: "AddToCart", payload: p })
                            addToRemoteCart(p)
                          }}><AiOutlineArrowUp /></button>
                          {/* </Col>
                        <Col> */}
                          <button className="btn-md btn-danger" onClick={() => {
                            dispatchCart({ type: "RemoveOneFromCart", payload: p.productId })
                            removeOneFromRemoteCart(p)
                          }}><AiOutlineArrowDown /></button>
                        </Col>
                      </Row>
                      {/* <Row className="d-flex justify-content-center align-items-center fs-6 text-white bg-dark">
                        Qty: {cart.filter(cp => cp.id === p.id).length}
                      </Row> */}
                    </Col>
                  </Row>
                </Container>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  )
}

export default ProductCard