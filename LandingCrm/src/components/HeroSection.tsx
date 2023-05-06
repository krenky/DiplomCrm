import {
    Button,
    Center,
    Container,
    Heading,
    Text,
    VStack,
  } from "@chakra-ui/react";
  import { FunctionComponent } from "react";
  
  interface HeroSectionProps {}
  
  export default function HeroSection() {
    return (
        <Container maxW="container.lg">
            <Center p={4} minHeight="70vh">
                <VStack>
                    <Container maxW="container.md" textAlign="center">
                        <Heading size="2xl" mb={4} color="gray.700">
                            Сломался телефон?
                        </Heading>

                        <Text fontSize="xl" color="gray.500">
                            Починим вашу технику за 1 день
                        </Text>

                        <Button
                            mt={8}
                            colorScheme="brand"
                            onClick={() => {
                                window.open("https://launchman.cc", "_blank");
                            } }
                        >
                            Заподнить заявку →
                        </Button>

                        <Text my={2} fontSize="sm" color="gray.500">
                            1000+ ремонтов каждый день по всей России
                        </Text>
                    </Container>
                </VStack>
            </Center>
        </Container>
    );
}