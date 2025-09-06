import React from "react";
import { Modal, Button, Card, Col, Form, Row } from "react-bootstrap";
import { Formik } from "formik";
import { Client } from "@/types/api/Client";
import { TextFormFieldType } from "@/components/form/TextFormField/TextFormFieldType";
import { TextFormField } from "@/components/form/TextFormField/TextFormField";
import { toastr } from "@/utils/toastr";
import ClientService from "@/services/ClientService";
import yup from "@/utils/yup";
import { handlePhoneNumberChange } from "@/helpers/handlePhoneNumberChange";
import { handleBirthDateChange } from "@/helpers/handleBirthDateChange";

interface ClientEditFormProps {
  show: boolean;
  onHide: () => void;
  client: Client;
  onSave: () => void;
}

const schemaValidation = yup.object().shape({
  firstName: yup.string().required("Nome é obrigatório"),
  lastName: yup.string().required("Sobrenome é obrigatório"),
  phoneNumber: yup.string().required("Telefone é obrigatório"),
  email: yup.string().email("Email inválido").required("Email é obrigatório"),
  documentNumber: yup.string().required("Documento é obrigatório"),
  birthDate: yup.string().required("Data de nascimento é obrigatório").length(10,'Data de nascimento deve conter 8 dígitos'),
  address: yup.object().shape({
    postalCode: yup.string().required("CEP é obrigatório"),
    addressLine: yup.string().required("Endereço é obrigatório"),
    number: yup.string().required("Número é obrigatório"),
    neighborhood: yup.string().required("Bairro é obrigatório"),
    city: yup.string().required("Cidade é obrigatória"),
    state: yup.string().required("Estado é obrigatório"),
  }),
});

const ClientEditForm: React.FC<ClientEditFormProps> = ({ show, onHide, client, onSave }) => {
  async function onSubmit(values: Client) {
    try {
      await ClientService.update(client.documentNumber, values);
      toastr({ title: "Cliente atualizado com sucesso", icon: "success" });
      onSave();
      onHide();
    } catch (err: any) {
      toastr({ title: "Erro", text: err.message, icon: "error" });
    }
  }

  return (
    <Modal show={show} onHide={onHide}>
      <Modal.Header closeButton>
        <Modal.Title>Editar Cliente</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Formik
          initialValues={client}
          validationSchema={schemaValidation}
          onSubmit={onSubmit}
          enableReinitialize={true}
        >
          {({
            handleSubmit,
            handleChange,
            handleBlur,
            errors,
            values,
            isSubmitting,
            isValid,
          }) => (
            <Form noValidate onSubmit={handleSubmit}>
                <Row>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="firstName"
                    label="Nome"
                    required
                    placeholder="Nome"
                    handleBlur={handleBlur}
                    handleChange={handleChange}
                    value={values.firstName}
                    formikError={errors.firstName}
                    />
                </Col>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="lastName"
                    label="Sobrenome"
                    required
                    placeholder="Sobrenome"
                    handleBlur={handleBlur}
                    handleChange={handleChange}
                    value={values.lastName}
                    formikError={errors.lastName}
                    />
                </Col>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="email"
                    label="Email"
                    required
                    placeholder="Email"
                    handleBlur={handleBlur}
                    handleChange={handleChange}
                    value={values.email}
                    formikError={errors.email}
                    />
                </Col>
                </Row>
                <Row>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="phoneNumber"
                    label="Telefone"
                    required
                    placeholder="Telefone"
                    handleBlur={handleBlur}
                    handleChange={(evnt) => handlePhoneNumberChange(evnt, handleChange)}
                    value={values.phoneNumber}
                    formikError={errors.phoneNumber}
                    />
                </Col>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="birthDate"
                    label="Data de Nascimento"
                    required
                    placeholder="dd/mm/aaaa"
                    handleBlur={handleBlur}
                    handleChange={(event) => handleBirthDateChange(event, handleChange)}
                    value={values.birthDate}
                    formikError={errors.birthDate}
                    />
                </Col>
                </Row>
                <br />
                <Row>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="address.postalCode"
                    label="CEP"
                    required
                    placeholder="CEP"
                    handleBlur={handleBlur}
                    handleChange={handleChange}
                    value={values.address.postalCode}
                    formikError={errors.address?.postalCode}
                    />
                </Col>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="address.addressLine"
                    label="Endereço"
                    required
                    placeholder="Endereço"
                    handleBlur={handleBlur}
                    handleChange={handleChange}
                    value={values.address.addressLine}
                    formikError={errors.address?.addressLine}
                    />
                </Col>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="address.number"
                    label="Número"
                    required
                    placeholder="Número"
                    handleBlur={handleBlur}
                    handleChange={handleChange}
                    value={values.address.number}
                    formikError={errors.address?.number}
                    />
                </Col>
                </Row>
                <Row>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="address.complement"
                    label="Complemento"
                    placeholder="Complemento"
                    handleBlur={handleBlur}
                    handleChange={handleChange}
                    value={values.address.complement}
                    formikError={errors.address?.complement}
                    />
                </Col>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="address.neighborhood"
                    label="Bairro"
                    required
                    placeholder="Bairro"
                    handleBlur={handleBlur}
                    handleChange={handleChange}
                    value={values.address.neighborhood}
                    formikError={errors.address?.neighborhood}
                    />
                </Col>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="address.city"
                    label="Cidade"
                    required
                    placeholder="Cidade"
                    handleBlur={handleBlur}
                    handleChange={handleChange}
                    value={values.address.city}
                    formikError={errors.address?.city}
                    />
                </Col>
                </Row>
                <Row>
                <Col md={4}>
                    <TextFormField
                    componentType={TextFormFieldType.INPUT}
                    name="address.state"
                    label="Estado"
                    required
                    placeholder="Estado"
                    handleBlur={handleBlur}
                    handleChange={handleChange}
                    value={values.address.state}
                    formikError={errors.address?.state}
                    />
                </Col>
                </Row>
                <br />
              <Button type="submit" variant="primary" disabled={!isValid || isSubmitting}>
                {isSubmitting ? "Salvando..." : "Salvar"}
              </Button>
              <Button
                variant="secondary"
                style={{ marginLeft: 5 }}
                onClick={onHide}
              >
                Cancelar
              </Button>
            </Form>
          )}
        </Formik>
      </Modal.Body>
    </Modal>
  );
};

export default ClientEditForm;