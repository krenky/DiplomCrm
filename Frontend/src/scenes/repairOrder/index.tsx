import { useEffect, useState } from 'react';
import {
    Box,
    Button,
    CircularProgress,
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    TextField,
    Typography,
    useMediaQuery,
    useTheme,

} from '@mui/material';
import { tokens } from '../../theme';
import { Customer, RepairOrder, StatusRepair } from '../../Type';
//import { getRepairOrder } from '../services/repairOrderService';
import { useParams } from 'react-router-dom';
import { Formik } from 'formik';
import * as yup from "yup";
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { ruRU } from '@mui/x-date-pickers/locales';
import dataProvider from '../../providers/dataProvider'

interface RepairOrderViewProps {
    id: string;
}

//const dataProvider = new DataProvider('https://localhost:7270/api');

const initialValues = {
    status: StatusRepair.InWork,
    description: "",
    startedAt: new Date(Date.now()),
    endedAt: new Date(Date.now()),
    created: new Date(Date.now()),
    updated: new Date(Date.now()),
    customerName: "",
    deviceName: ""
}
const userSchema = yup.object().shape({
    status: yup.string().required("required"),
    description: yup.string().required("required"),
    startedAt: yup.string().required("required"),
    endedAt: yup.string().required("required"),
    created: yup.string().required("required"),
    updated: yup.string().required("required"),
    customerName: yup.string().required("required"),
    deviceName: yup.string().required("required")
});

const RepairOrderView = ({ id }: RepairOrderViewProps) => {
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    const [loading, setLoading] = useState<boolean>(true);
    const [repairOrder, setRepairOrder] = useState<RepairOrder | null>(null);
    const isNonMobile = useMediaQuery("(min-width:600px)");
    const handleForSumbit = (values: any) => {
        console.log(values)
    }

    useEffect(() => {
        dataProvider.getOne<RepairOrder>('repairorders', id)
            .then((result) => {
                if (result.data)
                    setRepairOrder(result.data);
                if (result.data != null) {
                    const customer = result.data.customer || {} as Customer
                    initialValues.created = result.data.created
                    initialValues.updated = result.data.updated
                    initialValues.startedAt = result.data.startedAt
                    initialValues.endedAt = result.data.endedAt
                    initialValues.description = result.data.description
                    initialValues.status = result.data.status
                    initialValues.customerName = customer.firstName || ' ' + ' ' + customer.lastName|| ' '
                    initialValues.deviceName = result.data.device?.Name || ' '
                }
                setLoading(false);
            })
            .catch((error) => console.error(error));
    }, [id]);

    if (loading) {
        return <CircularProgress />;
    }

    if (!repairOrder) {
        return <Typography variant="h4">Repair order not found</Typography>;
    }

    return (
        <Box m="20px">
            <Formik
                onSubmit={handleForSumbit}
                initialValues={initialValues}
                validationSchema={userSchema}>
                {({ values,
                    errors,
                    touched,
                    handleBlur,
                    handleChange,
                    handleSubmit, }) => (
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
                                label="Статус"
                                onBlur={handleBlur}
                                onChange={handleChange}
                                value={StatusRepair[values.status]}
                                name="status"
                                error={!!touched.status && !!errors.status}
                                helperText={touched.status && errors.status}
                                sx={{ gridColumn: "span 2" }}
                            />
                            <TextField
                                fullWidth
                                variant="filled"
                                type="text"
                                label="Описание"
                                onBlur={handleBlur}
                                onChange={handleChange}
                                value={values.description.toString()}
                                name="description"
                                error={!!touched.description && !!errors.description}
                                helperText={touched.description && errors.description}
                                sx={{ gridColumn: "span 2" }}
                            />

                            <TextField
                                fullWidth
                                type="text"
                                label="Дата создания"
                                onBlur={handleBlur}
                                onChange={handleChange}
                                value={values.created}
                                name="created"
                                error={!!touched.created && !!errors.created}
                                //helperText={touched.created && errors.created}
                                sx={{ gridColumn: "span 2" }}

                            />
                            <TextField
                                fullWidth
                                type="text"
                                label="Дата обновления"
                                onBlur={handleBlur}
                                onChange={handleChange}
                                value={values.updated}
                                name="updated"
                                error={!!touched.updated && !!errors.updated}
                                //helperText={touched.updated && errors.updated}
                                sx={{ gridColumn: "span 2" }}

                            />
                            <TextField
                                fullWidth
                                type="text"
                                label="Дата начало ремонта"
                                onBlur={handleBlur}
                                onChange={handleChange}
                                value={values.startedAt}
                                name="startedAt"
                                error={!!touched.startedAt && !!errors.startedAt}
                                //helperText={touched.startedAt && errors.startedAt}
                                sx={{ gridColumn: "span 2" }}

                            />
                            <TextField
                                fullWidth
                                type="text"
                                label="Дата окончания ремонта"
                                onBlur={handleBlur}
                                onChange={handleChange}
                                value={values.endedAt}
                                name="endedAt"
                                error={!!touched.endedAt && !!errors.endedAt}
                                //helperText={touched.endedAt.toString()||'' && errors.endedAt.toDateString()}
                                sx={{ gridColumn: "span 2" }}
                            />
                            <TextField
                                fullWidth
                                type="text"
                                label="ФИО клиента"
                                onBlur={handleBlur}
                                onChange={handleChange}
                                value={values.customerName}
                                name="customerName"
                                error={!!touched.customerName && !!errors.customerName}
                                helperText={touched.customerName||'' && errors.customerName}
                                sx={{ gridColumn: "span 2" }}
                            />
                            <TextField
                                fullWidth
                                type="text"
                                label="Наименование устройства"
                                onBlur={handleBlur}
                                onChange={handleChange}
                                value={values.deviceName}
                                name="deviceName"
                                error={!!touched.deviceName && !!errors.deviceName}
                                helperText={touched.deviceName||'' && errors.deviceName}
                                sx={{ gridColumn: "span 2" }}
                            />
                            {/* <TextField
                                fullWidth
                                type="text"
                                label="ФИО менеджера"
                                onBlur={handleBlur}
                                onChange={handleChange}
                                value={values.endedAt}
                                name="endedAt"
                                error={!!touched.endedAt && !!errors.endedAt}
                                //helperText={touched.endedAt.toString()||'' && errors.endedAt.toDateString()}
                                sx={{ gridColumn: "span 2" }}
                            /> */}
                        </Box>
                        <Box display="flex" justifyContent="end" mt="20px">
                            <Button type="submit" color="secondary" variant="contained" onClick={() => {
                                const user: RepairOrder = {
                                    status: values.status,
                                    description: values.description,
                                    startedAt: values.startedAt,
                                    endedAt: values.endedAt,
                                    created: values.created,
                                    updated: values.updated
                                }
                                SaveRepairOrder(user, id);
                            }}>
                                Сохранение данных
                            </Button>
                        </Box>
                    </form>
                )}
            </Formik>
        </Box>
    );
};
export function RepairOrderFormik() {
    const theme = useTheme();
    const params = useParams();
    const id = params.id || '0';
    return (
        <RepairOrderView id={id} />
    );
}
function SaveRepairOrder(order: RepairOrder, id: string) {
    dataProvider.update<RepairOrder>('repairorders', id, order)
}

function RepairOrderForRouteView() {
    const theme = useTheme();
    const params = useParams();
    const id = params.id || '0';
    const colors = tokens(theme.palette.mode);
    const [loading, setLoading] = useState<boolean>(true);
    const [repairOrder, setRepairOrder] = useState<RepairOrder | null>(null);

    useEffect(() => {
        dataProvider.getOne<RepairOrder>('repairorders', id)
            .then((result) => {
                if (result.data)
                    setRepairOrder(result.data);
                setLoading(false);
            })
            .catch((error) => console.error(error));
    }, [id]);

    if (loading) {
        return <CircularProgress />;
    }

    if (!repairOrder) {
        return <Typography variant="h4">Repair order not found</Typography>;
    }

    return (
        <Box m="20px">
            <Typography variant="h4" gutterBottom>
                Repair Order #{id}
            </Typography>

            <TableContainer component={Paper}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Status</TableCell>
                            <TableCell>{repairOrder.status.toString()}</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        <TableRow>
                            <TableCell>Description</TableCell>
                            <TableCell>{repairOrder.description}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell>Status</TableCell>
                            <TableCell>{repairOrder.status.toString()}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell>Started At</TableCell>
                            <TableCell>{repairOrder.startedAt.toLocaleString()}</TableCell>
                        </TableRow>
                        {repairOrder.endedAt && (
                            <TableRow>
                                <TableCell>Ended At</TableCell>
                                <TableCell>{repairOrder.endedAt.toLocaleString()}</TableCell>
                            </TableRow>
                        )}
                        <TableRow>
                            <TableCell>Created At</TableCell>
                            <TableCell>{repairOrder.created.toLocaleString()}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell>Updated At</TableCell>
                            <TableCell>{repairOrder.updated.toLocaleString()}</TableCell>
                        </TableRow>
                    </TableBody>
                </Table>
            </TableContainer>

            <Box mt="20px">
                <Button variant="contained" color="primary" onClick={() => console.log('Edit')}>
                    Edit
                </Button>
            </Box>
        </Box>
    );
}

export default RepairOrderForRouteView;
