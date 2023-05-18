import { Box, Button, Modal, TextField, useTheme } from "@mui/material";
import { Formik } from "formik";
import * as yup from "yup";
import useMediaQuery from "@mui/material/useMediaQuery";
import Header from "../../components/Header";
import { Customer, RegisterModel } from "../../Type"
import React from "react";
import { tokens } from "../../theme";
import dataProvider, { RequestOptions, DataProviderResponse, DataProvider } from '../../providers/dataProvider'

const phoneRegExp =
    /^((\+[1-9]{1,4}[ -]?)|(\([0-9]{2,3}\)[ -]?)|([0-9]{2,4})[ -]?)*?[0-9]{3,4}[ -]?[0-9]{3,4}$/;

const initialValues = {
    firstName: "string",
    lastName: "string",
    phone: "string",
    email: "string",
    birthdate: new Date(Date.now())
}
const userSchema = yup.object().shape({
    firstName: yup.string().required("required"),
    lastName: yup.string().required("required"),
    phone: yup
        .string()
        .matches(phoneRegExp, "Phone number is not valid")
        .required("required"),
    email: yup.string().email("invalid email").required("required"),
    birthdate: yup.string().required("required"),
});

const RegisterCustomer = () => {
    const isNonMobile = useMediaQuery("(min-width:600px)");
    const handleForSumbit = (values: any) => {
        console.log(values)
    }

    return <Box m={"20px"}>
        <Header title="Регистрация клиента" subtitle="Регистрация нового клиента" />
        <Formik
            onSubmit={handleForSumbit}
            initialValues={initialValues}
            validationSchema={userSchema}>
            {({
                values,
                errors,
                touched,
                handleBlur,
                handleChange,
                handleSubmit,
            }) => (
                <form onSubmit={handleSubmit}>
                    <Box
                        display="grid"
                        gap="30px"
                        gridTemplateColumns="repeat(4, minmax(0, 1fr))"
                        sx={{
                            "& > div": { gridColumn: isNonMobile ? undefined : "span 4" },
                        }}
                    >
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Имя"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.firstName}
                            name="firstName"
                            error={!!touched.firstName && !!errors.firstName}
                            helperText={touched.firstName && errors.firstName}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Фаимлия"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.lastName}
                            name="lastName"
                            error={!!touched.lastName && !!errors.lastName}
                            helperText={touched.lastName && errors.lastName}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Email"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.email}
                            name="email"
                            error={!!touched.email && !!errors.email}
                            helperText={touched.email && errors.email}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Номер телефона"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.phone}
                            name="phone"
                            error={!!touched.phone && !!errors.phone}
                            helperText={touched.phone && errors.phone}
                            sx={{ gridColumn: "span 4" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="День рождения"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.birthdate}
                            name="birthdate"
                            error={!!touched.birthdate && !!errors.birthdate}
                            //helperText={touched.birthdate && errors.birthdate}
                            sx={{ gridColumn: "span 4" }}
                        />
                    </Box>
                    <Box display="flex" justifyContent="end" mt="20px">
                        <Button type="submit" color="secondary" variant="contained" onClick={() => {
                            const user: Customer = {
                                firstName: values.firstName,
                                lastName: values.lastName,
                                phone: values.phone,
                                email: values.email,
                                birthdate: new Date(values.birthdate)
                            }
                            CreatUser(user);
                        }}>
                            Create New User
                        </Button>
                    </Box>
                </form>
            )}
        </Formik>
    </Box>
}

//const Moda

export const ModalForm = (props: { open: boolean, handleClose: () => void }) => {
    const [open, setOpen] = React.useState(false);
    //const handleOpen = () => setOpen(true);
    //const handleClose = () => setOpen(false);
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    return (
        <Modal
            open={props.open}
            onClose={props.handleClose}
            sx={{
                width: '100%', height: '100%', bgcolor: 'white'
            }}
        // aria-labelledby="modal-modal-title"
        // aria-describedby="modal-modal-description"
        >
            <Box>
                <RegisterCustomer />
            </Box>
        </Modal>)
}

function CreatUser(user: Customer) {
    dataProvider.create<Customer>('Customers', user)
        .then(value => { return value.data })
        .catch(reason => { return reason });
}


export default RegisterCustomer;