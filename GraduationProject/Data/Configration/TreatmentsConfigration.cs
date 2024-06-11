using GraduationProject.API.Data;
using GraduationProject.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.API.Data.Seeds
{
    public class TreatmentsConfigration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasData(new List<Treatment>
                {
                    new Treatment {Id=1, Title = "Tomato Mosaic Virus",Key="Tomato___Tomato_mosaic_virus", Content = "There are several tomato varieties resistant to ToMV. Studies have found that tomatoes containing the Tm-22 gene could specifically resist to ToMV strains ToMV-0, ToMV-1 and ToMV-2. or ToMV is transmitted from plant to plant through vegetative propagation, grafting, and seeds. It is significantly important to ensure that any seeds planted are virus-free. This blocks ToMV from being spread to healthy plants through mechanical activities." },
                    new Treatment {Id=2, Title = "Target Spot",Key="Tomato___Target_Spot",  Content = "The products to use are chlorothalonil, copper oxychloride or mancozeb. Treatment should start when the first spots are seen and continue at 10-14-day intervals until 3-4 weeks before last harvest." },
                    new Treatment {Id=3, Title = "Bacterial Spot",Key="Tomato___Bacterial_spot",  Content = "For homeowners, copper products or copper plus mancozeb are registered and effective to control bacterial spot of tomato. For commercial growers, control of bacterial spot on greenhouse transplants by using streptomycin can prevent spread of the disease in the field." },
                    new Treatment {Id=4, Title = "Tomato Yellow Leaf Curl Virus", Key="Tomato___Tomato_Yellow_Leaf_Curl_Virus", Content = "Once infected with the virus, there are no treatments against the infection. Control the whitefly population to avoid the infection with the virus. Insecticides of the family of the pyrethroids used as soil drenches or spray during the seedling stage can reduce the population of whiteflies." },
                    new Treatment {Id=5, Title = "Late Blight", Key="Tomato___Late_blight", Content = "Strategies for managing late blight in tomato include planting resistant cultivars, eliminating volunteers (tomato plants that have re-seeded from the previous year's crop), spacing plants to increase airflow and reduce humidity, and applying preventive and effective fungicides to avoid infection." },
                    new Treatment {Id=6, Title = "Leaf Mold", Key="Tomato___Leaf_Mold", Content = "Remove and destroy all affected plant parts. For plants growing under cover, increase ventilation and, if possible, the space between plants. Try to avoid wetting the leaves when watering plants, especially when watering in the evening. Copper-based fungicides can be used to control diseases on tomatoes." },
                    new Treatment {Id=7, Title = "Early Blight", Key="Tomato___Early_blight", Content = "Fungicides, crop rotation, and removal of infected plant material are key management practices and Give your tools a quick scrub to remove soil, then dip or spray them with a mild bleach solution." },
                    new Treatment {Id=8, Title = "Two-Spotted Spider Mites", Key="Tomato___Spider_mites Two-spotted_spider_mite", Content = "Miticides, predatory mites, and maintaining plant vigor help control spider mite infestations." },
                    new Treatment {Id=9, Title = "Septoria Leaf Spot", Key="Tomato___Septoria_leaf_spot", Content = "Remove diseased leaves, improve air circulation around the plants, mulch around the base of the plants, do not use overhead watering, control weeds, use crop rotation, and use fungicidal sprays." },
                    new Treatment {Id=10, Title = "Tomato healthy", Key="Tomato___healthy", Content = " " }
                });

          
        }
    }
}
