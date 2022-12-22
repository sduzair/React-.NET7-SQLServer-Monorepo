import React, { useState } from 'react'
// import { useForm } from "react-hook-form";
// import { Form, Input, Row, Col, Upload, Button } from 'antd';
import { Form as FormBootstrap } from 'react-bootstrap'
// import { LoadingOutlined, PlusOutlined } from '@ant-design/icons';
// import TextArea from 'antd/lib/input/TextArea';

const NewProductPage = () => {

  // const [myForm] = Form.useForm();
  // const [fileList, setFileList] = useState([]);
  // const [uploadItems, setUploadItems] = useState([]);
  // const [signedURL, setSignedURL] = useState("");
  // const [uploadURL] = useState();

  // const onFinish = async (e) => {
  //   saveElement(e);
  // };

  // const saveElement = async (e) => {
  //   // console.log(e);
  //   const updateRes = await fetch("api/Products/NewProduct", {
  //     method: "POST",
  //     headers: {
  //       "Content-Type": "application/json",
  //     },
  //     body: JSON.stringify(e),
  //   });
  //   // console.log(updateRes);
  // };

  // const handleBeforeUpload = async (data) => {
  //   const name = uuidv4();
  //   const ext = data.type.split("/");
  //   const payload = {
  //     variables: {
  //       fileName: 'entity/' + name,
  //       fileType: ext[ext.length - 1]
  //     }
  //   };
  //   const URL = await uploadURL(payload)
  //   setSignedURL(URL.data.generateUrl);
  //   setUploadItems([
  //     ...uploadItems,
  //     { url: URL.data.generateUrl.split('?')[0], fileId: data.uid },
  //   ]);
  // };

  // const handleUpload = async ({ onSuccess, onError, file }) => {
  //   try {
  //     var options = {
  //       headers: {
  //         "Content-Type": file.type,
  //       },
  //     };

  //     await axios.put(signedURL, file, options);
  //     onSuccess(null, file);
  //   } catch (err) {
  //     onError(err.message, err.message, file);
  //   }
  // };

  // const handleFileChanged = ({ file }) => {
  //   if (file.status === "removed") {
  //     setFileList([]);
  //   } else if (file.status === "uploading") {
  //     setFileList([file]);
  //   }
  //   else if (file.status === "done") {
  //     notification.success({ message: "Image updated successfully" });
  //   }
  // };

  // const onRemove = async () => {
  //   setUploadItems([]);
  // };

  // const onFinishFailed = (e) => {
  //   console.log(e);
  // };

  // const uploadButton = (
  //   <div>
  //     {<PlusOutlined />}
  //     <div style={{ marginTop: 8 }}>Upload</div>
  //   </div>
  // );

  return (
    <div>
      <h1>New Product</h1>
      {/* <center>
        <Form
          form={myForm}
          layout="vertical"
          id="myForm"
          name="myForm"
          onFinish={onFinish}
          onFinishFailed={onFinishFailed}
        >
          <Row gutter={16}>
            {/* <Col span={24}>
              <Form.Item label={"Upload an image"}
                className="mb-2">
                <Upload
                  id="logo"
                  action={signedURL}
                  fileList={fileList}
                  multiple={false}
                  listType="picture-card"
                  // onPreview={onPreview}
                  onRemove={(e) => onRemove(e)}
                  customRequest={(e) => handleUpload(e)}
                  beforeUpload={(args) =>
                    handleBeforeUpload(args)
                  }
                  onChange={(e) => handleFileChanged(e)}
                >
                  {fileList.length === 0 && uploadButton}
                </Upload>
              </Form.Item>
            </Col> *
            <Col span={12}>
              <Form.Item
                label="Title"
                className="mb-2"
                name="title"
                rules={[
                  {
                    required: true,
                    message: 'Please enter title',
                  },
                  {
                    whitespace: true,
                    message: "Title should not contain only whitespaces!",
                  },
                  {
                    min: 1,
                    max: 100
                  }
                ]}>
                <Input />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item
                label="Description"
                className="mb-2"
                name="description"
                rules={[
                  {
                    whitespace: true,
                    message: "Description should not contain only whitespaces!",
                  }
                ]}>
                <Input />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item
                label="Brand"
                className="mb-2"
                name="brand"
                rules={[
                  {
                    required: true,
                    message: 'Please enter brand',
                  },
                  {
                    whitespace: true,
                    message: "Title should not contain only whitespaces!",
                  },
                  {
                    min: 1,
                    max: 100
                  }
                ]}>
                <Input />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item
                label="Category"
                className="mb-2"
                name="category"
                rules={[
                  {
                    required: true,
                    message: 'Please enter category',
                  },
                  {
                    whitespace: true,
                    message: "Title should not contain only whitespaces!",
                  },
                  {
                    min: 1,
                    max: 100
                  }
                ]}>
                {/* <Select> 
                {/* <Option value="1">Category 1</Option> */}

      {/* </Select> *
                <FormBootstrap.Select aria-label="Default select example">
                  {
                    [
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
                    ].map((category, i) => <option key={i} value={category}>{category}</option>)
                  }
                </FormBootstrap.Select>
              </Form.Item>
            </Col>
            <Col span={24}>
              <Form.Item
                label="Price"
                className="mb-2"
                name="price"
                rules={[
                  {
                    min: 1,
                    max: 100
                  }
                ]}>
                <Input />
              </Form.Item>
            </Col>
            <Col span={24}>
              <Form.Item
                label="Discount Percentage"
                className="mb-2"
                name="discountPercentage"
                rules={[
                  {
                    min: 1,
                    max: 100
                  }
                ]}>
                <Input />
              </Form.Item>
            </Col>
            <Col span={24}>
              <Form.Item
                label="Rating"
                className="mb-2"
                name="rating"
                rules={[
                  {
                    min: 1,
                    max: 100
                  }
                ]}>
                <Input />
              </Form.Item>
            </Col>
            <Col span={24}>
              <Form.Item
                label="Stock"
                className="mb-2"
                name="stock"
                rules={[
                  {
                    min: 1,
                    max: 100
                  }
                ]}>
                <Input />
              </Form.Item>
            </Col>
            <Col span={24}>
              <Form.Item
                label="Description"
                className="mb-2"
                name="description"
                rules={[
                  {
                    whitespace: true,
                    message: "Description should not contain only whitespaces!",
                  }
                ]}>
                <TextArea />
              </Form.Item>
            </Col>
            <Button form="myForm" htmlType="submit" type="primary">
              Submit
            </Button>
          </Row>
        </Form>
      </center> */}
    </div>
  )
}

export default NewProductPage