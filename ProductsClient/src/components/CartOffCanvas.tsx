import React from 'react'
import { Offcanvas, Container, Row, Col } from "react-bootstrap";
import { AiOutlineArrowUp, AiOutlineArrowDown } from 'react-icons/ai'
import { BiDollarCircle } from 'react-icons/bi'
import { RiDeleteBinLine } from 'react-icons/ri'
import { addToRemoteCart, removeOneFromRemoteCart, removeAllOfOneFromRemoteCart } from '../util/serverCart'

const options = {
  name: 'Enable body scrolling',
  scroll: true,
  backdrop: false,
  placement: 'end'
}

function OffCanvas({ cart, dispatch, show, handleClose }) {
  // var uniqueProductsInCart = [...new Set(cart)]
  const uniqueProductsInCart = [...new Map(cart.map(item =>
    [item['id'], item])).values()];
  return (
    <>
      <Offcanvas className="h-auto mt-5 border border-dark border-3 rounded" show={show} onHide={handleClose} {...options}>
        <Offcanvas.Header closeButton>
          <Offcanvas.Title>My Cart</Offcanvas.Title>
        </Offcanvas.Header>
        <Offcanvas.Body>
          <Container fluid className="fs-6">
            {uniqueProductsInCart.map((p, i) =>
              <Row key={i}>
                <Col>
                  <div className="card" >
                    <div className="card-header small">
                      <Row>
                        <Col>
                          {p.title}
                        </Col>
                        <Col xs="auto" className="d-flex align-items-center px-0">
                          <button className="btn-sm btn-outline-danger py-0 d-flex justify-content-center align-items-center" onClick={() => { removeAllOfOneFromRemoteCart(p); dispatch({ type: "RemoveAllFromCart", payload: p.id }) }}>
                            <RiDeleteBinLine />
                          </button>
                        </Col>
                      </Row>
                    </div>
                    <div className="card-body">
                      {/* <h5 className="card-title small">{p.title}</h5> */}
                      {/* <p className="card-text small">{p.category}</p> */}
                      <Row>
                        <Col>
                          <Row className="justify-content-start">
                            <Col xs="auto" className="d-flex justify-content-center align-items-center fs-6 text-white ">
                              <div className='d-flex justify-content-center align-items-center bg-success' style={{ width: 60 }}><BiDollarCircle />{p.price}</div>
                            </Col>
                          </Row>
                        </Col>
                        <Col>
                          <Row className="justify-content-end">
                            <Col xs="auto" className="d-flex justify-content-center align-items-center fs-6 text-white bg-dark">
                              {cart.filter(cp => cp.id === p.id).length}
                            </Col>
                            <Col xs="auto" className="d-flex align-items-center px-0">
                              <button className="btn-sm btn-outline-primary py-0" onClick={() => {
                                dispatch({ type: "AddToCart", payload: p })
                                addToRemoteCart(p)
                              }}><AiOutlineArrowUp /></button>
                              <button className="btn-sm btn-outline-danger py-0" onClick={() => {
                                dispatch({ type: "RemoveOneFromCart", payload: p.id })
                                removeOneFromRemoteCart(p)
                              }}><AiOutlineArrowDown /></button>
                            </Col>
                          </Row>
                        </Col>
                      </Row>
                    </div>
                  </div>
                </Col>
              </Row>)}
          </Container>
        </Offcanvas.Body>
      </Offcanvas>
    </>
  );
}

export default OffCanvas