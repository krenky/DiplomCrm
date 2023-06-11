import { Box, Button, CircularProgress, Modal, TextField, useMediaQuery, useTheme } from "@mui/material";
import * as yup from "yup";
import Header from "../../components/Header";
import { Formik } from "formik";
import { AdvertisingСompany } from "../../Type";
import dataProvider from "../../providers/dataProvider";
import { tokens } from "../../theme";
import { useEffect, useState } from "react";




const AdvertisingСompanyChange = (props: { company: AdvertisingСompany | undefined }) => {
    const isNonMobile = useMediaQuery("(min-width:600px)");
    const handleForSumbit = (values: any) => {
        console.log(values)
    }
    const initialValues = {
        name: props.company?.name,
        discount: props.company?.discount,
        description: props.company?.description,
        code: props.company?.code
    }
    const userSchema = yup.object().shape({
        name: yup.string().required("required"),
        discount: yup.number().required("required"),
        description: yup.string().required("required"),
        code: yup.string().required("required"),
    });
    return <Box m={"20px"}>
        <Header title="Редактирование рекламной компании" subtitle="Редактирование рекламной компании" />
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
                            label="Наименование компании"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.name}
                            name="name"
                            error={!!touched.name && !!errors.name}
                            //helperText={touched.name && errors.name}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="number"
                            label="Скидка в %"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.discount}
                            name="discount"
                            error={!!touched.discount && !!errors.discount}
                            helperText={touched.discount && errors.discount}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Описание"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.description}
                            name="description"
                            error={!!touched.description && !!errors.description}
                            helperText={touched.description && errors.description}
                            sx={{ gridColumn: "span 4" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Промо-код"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.code}
                            name="code"
                            error={!!touched.code && !!errors.code}
                            helperText={touched.code && errors.code}
                            sx={{ gridColumn: "span 4" }}
                        />
                    </Box>
                    <Box display="flex" justifyContent="end" mt="20px">
                        <Button type="submit" color="secondary" variant="contained" onClick={() => {
                            if (values) {
                                const user: AdvertisingСompany = {
                                    id: props.company?.id,
                                    name: values.name?values.name:'',
                                    discount: values.discount?values.discount:0,
                                    description: values.description?values.description:'',
                                    code: values.code?values.code:''
                                }
                                CreateCompany(user);
                            }
                        }}>
                            Обновление
                        </Button>
                    </Box>
                </form>
            )}
        </Formik>
    </Box>
}


export const AdvertisingСompanyChangeModal = (props: { open: boolean, handleClose: () => void, order: AdvertisingСompany | undefined }) => {
    const [open, setOpen] = useState(false);
    //const handleOpen = () => setOpen(true);
    //const handleClose = () => setOpen(false);
    const [loading, setLoading] = useState<boolean>(false);
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    const style = {
        position: 'absolute' as 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: '100%',
        bgcolor: colors.primary[200],
        border: '2px solid #000',
        boxShadow: 24,
        pt: 2,
        px: 4,
        pb: 3,
    };
    // useEffect(() => {
    //     dataProvider.getList<InventoryItem>('InventoryItems')
    //         .then((result) => {
    //             if (result.data) {
    //                 setParts(result.data)

    //             }

    //         })
    //     dataProvider.getList<RepairWork>('RepairWorks')
    //         .then((result) => {
    //             if (result.data) {
    //                 setWorks(result.data)
    //                 setLoading(false);
    //             }

    //         })
    // }, [])

    if (loading) {
        return <CircularProgress />;
    }



    return (
        <Modal
            open={props.open}
            onClose={props.handleClose}
            sx={{
                width: '60%', height: '60%', position: 'center'/*, bgcolor: colors.blueAccent[100]*/
            }}
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description"
        >
            <Box borderColor={colors.greenAccent} sx={{ ...style }} /*</Modal>bgcolor={colors.grey[400]}*/>
                <AdvertisingСompanyChange company={props.order} />
            </Box>
        </Modal>)
}

export default AdvertisingСompanyChange;

function CreateCompany(company: AdvertisingСompany) {
    dataProvider.update<AdvertisingСompany>('AdvertisingСompany', company.id || '-1', company);
}