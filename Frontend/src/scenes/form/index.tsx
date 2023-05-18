import { Box, Button, Modal, TextField, useTheme } from "@mui/material";
import { Formik } from "formik";
import * as yup from "yup";
import useMediaQuery from "@mui/material/useMediaQuery";
import Header from "../../components/Header";
import { RegisterModel } from "../../Type"
import React from "react";
import { tokens } from "../../theme";
import dataProvider, { RequestOptions, DataProviderResponse, DataProvider } from '../../providers/dataProvider'

const phoneRegExp =
    /^((\+[1-9]{1,4}[ -]?)|(\([0-9]{2,3}\)[ -]?)|([0-9]{2,4})[ -]?)*?[0-9]{3,4}[ -]?[0-9]{3,4}$/;

const initialValues = {
    userName: "",
    email: "",
    phoneNumber: "",
    password: ""
}
const userSchema = yup.object().shape({
    userName: yup.string().required("required"),
    email: yup.string().email("invalid email").required("required"),
    phoneNumber: yup
        .string()
        .matches(phoneRegExp, "Phone number is not valid")
        .required("required"),
    password: yup.string().required("required"),
});

const Form = () => {
    const isNonMobile = useMediaQuery("(min-width:600px)");
    const handleForSumbit = (values: any) => {
        console.log(values)
    }

    return <Box m={"20px"}>
        <Header title="Регистрация сотрудника" subtitle="Регистрация нового сотрудника" />
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
                            label="ФИО"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.userName}
                            name="userName"
                            error={!!touched.userName && !!errors.userName}
                            helperText={touched.userName && errors.userName}
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
                            value={values.phoneNumber}
                            name="phoneNumber"
                            error={!!touched.phoneNumber && !!errors.phoneNumber}
                            helperText={touched.phoneNumber && errors.phoneNumber}
                            sx={{ gridColumn: "span 4" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Password"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.password}
                            name="password"
                            error={!!touched.password && !!errors.password}
                            helperText={touched.password && errors.password}
                            sx={{ gridColumn: "span 4" }}
                        />
                    </Box>
                    <Box display="flex" justifyContent="end" mt="20px">
                        <Button type="submit" color="secondary" variant="contained" onClick={() => {
                            const user: RegisterModel = {
                                userName: values.userName,
                                email: values.email,
                                phoneNumber: values.phoneNumber,
                                password: values.password,
                                userRole: 1
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
                <Form />
            </Box>
        </Modal>)
}

function CreatUser(user: RegisterModel) {
    dataProvider.create<RegisterModel>('Authenticate/register', user)
        .then(value => { return value.data })
        .catch(reason => { return reason });
}


export default Form;