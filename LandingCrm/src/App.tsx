import {
  Box,
  Center,
  Container,
  Wrap,
  WrapItem,
  Text,
  Image,
  VStack,
  SimpleGrid,
  Flex,
  LinkBox,
  LinkOverlay,
  Spacer,
} from "@chakra-ui/react";
import HeroSection from "./components/HeroSection";
import Layout from "./components/Layout";
import { Feature } from "./components/Feature";
import { PricingSection } from "./components/PricingSection";
import { FAQSection, FAQType } from "./components/FAQSection";
import { CTA } from './components/CTA';
import twitterLogo from './assets/twitter-logo.svg';
import posterBil from './assets/biller-hero-2.png';
import video from "./assets/biller-hero-2.webm";
import microsoftLogo from './assets/microsoft-logo.svg'
import adobeLogo from './assets/adobe-logo.svg'
import {Helmet} from 'fusion-plugin-react-helmet-async';
import {toast} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';



interface FeatureType {
  title: string
  description: string
  image: string
}

const features: FeatureType[] = [
  {
    title: "Быстрый ремонт",
    description:
      "Починим вашу технику в течении следующего дня, если не успеем дадим скидку 50%",
    image:
      "https://img.freepik.com/free-photo/closeup-on-smartphone-after-screen-replacement-service_346278-1209.jpg",
  },
  {
    title: "Гарантия качества",
    description:
      "Даем гарантию от 1 года",
    image:
      "https://img.freepik.com/free-photo/electronic-technician-holds-two-identical-smartphones-for-comparison-in-one-hand-broken-and-in-another-new_613910-20299.jpg",
  },
  {
    title: "Забота о вашем времени",
    description:
      "Если вы не имеете возможности принести вашу технику к нам, мы отправим к вам курьера",
    image:
      "https://img.freepik.com/free-photo/close-up-hands-holding-fragile-pack-and-phone_23-2149035901.jpg",
  },
];

const faqs: FAQType[] = [
  {
    q: 'Доставка бесплатная?',
    a: 'Да, доставка бесплатная',
  },
  {
    q: 'Вы чините технику Apple',
    a: 'Да, мы лицензированный сервсиный центр, все запчасти от оффициального производителя apple',
  },
  {
    q: 'Оплата производится до ремонта или после?',
    a: 'Оплата производится после приемки и вывления причины поломки нашим мастеров',
  },
  {
    q: 'Могу ли я оплатить онлайн?',
    a: 'Да, оплата онлайн присутствует',
  },
]


export interface HighlightType {
  icon: string
  title: string
  description: string
}

const highlights: HighlightType[] = [
      {
        icon: '✨',
        title: 'No-code',
        description:
          "We are No-Code friendly. There is no coding required to get started. Launchman connects with Airtable and lets you generate a new page per row. It's just that easy!",
      },
      {
        icon: '🎉',
        title: 'Make Google happy',
        description:
          "We render all our pages server-side; when Google's robots come to index your site, the page does not have to wait for JS to be fetched. This helps you get ranked higher.",
      },
      {
        icon: '😃',
        title: 'Rapid experimenting',
        description:
          "You don't have to wait hours to update your hard-coded landing pages. Figure out what resonates with your customers the most and update the copy in seconds",
      },
      {
        icon: '🔌',
        title: 'Rapid experimenting',
        description:
          "You don't have to wait hours to update your hard-coded landing pages. Figure out what resonates with your customers the most and update the copy in seconds",
      },
    ]


export const App = () => {

  return (
    <Layout>
      <Box bg="gray.50">
        <HeroSection />
        
        <Container maxW="container.2xl" centerContent py={[20]}>
          <text color="gray.600" fontSize="lg">
          Used by teams worldwide
          </text>  
          <Wrap 
          spacing={[10, 20]}
          mt={8}
          align="center"
          justify="center"
          w="full">
            <WrapItem>
                <Image src={microsoftLogo} alt="Microsoft logo" />
              </WrapItem>

              <WrapItem>
                <Image src={adobeLogo} alt="Adobe logo" />
              </WrapItem>

              <WrapItem>
                <Image src={microsoftLogo} alt="Microsoft logo" />
              </WrapItem>

              <WrapItem>
                <Image src={adobeLogo} alt="Adobe logo" />
              </WrapItem>
          </Wrap>
        </Container>
        <VStack
          backgroundColor="white"
          w="full"
          id="features"
          spacing={16}
          py={[16, 0]}
        >
          {features.map(
            ({ title, description, image }: FeatureType, i: number) => {
              return (
                <Feature
                  key={`feature_${i}`}
                  title={title}
                  description={description}
                  image={image}
                  reverse={i % 2 === 1}
                />
              )
            }
          )}
        </VStack>
        <Container maxW="container.md" centerContent py={[8, 28]}>
          <SimpleGrid spacingX={10} spacingY={20} minChildWidth="300px">
            {highlights.map(({ title, description, icon }, i: number) => (
              <Box p={4} rounded="md" key={`highlight_${i}`}>
                <Text fontSize="4xl">{icon}</Text>

                <Text fontWeight={500}>{title}</Text>

                <Text color="gray.500" mt={4}>
                  {description}
                </Text>
              </Box>
            ))}
          </SimpleGrid>
        </Container>
        <Container py={28} maxW="container.lg" w="full" id="pricing">
          <PricingSection />
        </Container>
        <Container py={28} maxW="container.md">
          <Box w="full">
            <VStack spacing={10} w="full">
              <Text fontWeight={500} fontSize="2xl" align="center">
                Frequently asked questions
              </Text>
              <FAQSection items={faqs} />
            </VStack>
          </Box>
        </Container>
        <CTA
          heading={`Get started with Biller  today!`}
          cta={{ name: 'I want this!', link: '#' }}
        />
        <Container maxW="container.lg">
          <Flex py={6}>
            <Box>
              <Text>© 2022 Biller</Text>

              <Text>Made by Sukh</Text>
            </Box>
            <Spacer />

            <LinkBox>
              <LinkOverlay href="https://twitter.com/@thisissukh_" isExternal>
                <Image src={twitterLogo} alt="Twitter logo"></Image>
              </LinkOverlay>
            </LinkBox>
          </Flex>
        </Container>
      </Box>
    </Layout>
  );
};